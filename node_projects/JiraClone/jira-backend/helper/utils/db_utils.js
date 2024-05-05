const path = require('path');
const { getFilePaths } = require('./path_utils.js');
const { readFile } = require('./file_utils.js');
const { runStatementsSerial } = require('../../lib/db/utils.js');
const { promiseFnAllSequential } = require('../../lib/utils/promise_utils.js')

function getDbMigrationsInOrder() {
    let migrationFilePaths = getFilePaths(
        path.join(__dirname, '..', 'scripts', 'db', 'migrations')
    );
    migrationFilePaths = migrationFilePaths.filter(path => path.endsWith('.sql'));
    migrationFilePaths.sort();
    return migrationFilePaths;
}

function getDbDataPopulationFilesInOrder() {
    let populationFilePaths = getFilePaths(
        path.join(__dirname, '..', 'scripts', 'db', 'data-population')
    );
    populationFilePaths = populationFilePaths.filter(path => path.endsWith('.sql'));
    populationFilePaths.sort();
    return populationFilePaths;
}

function setupDb(db) {
    const migrationFilePaths = getDbMigrationsInOrder();
    const populationFilePaths = getDbDataPopulationFilesInOrder();
    
    return new Promise((resolve, reject) => {
        dbFns = [
            () => console.log("Run migration"),
            () => runStatementsSerial(db, migrationFilePaths.map(path => readFile(path))),
            () => console.log("Run population"),
            () => runStatementsSerial(db, populationFilePaths.map(path => readFile(path)))
        ]
        promiseFnAllSequential(dbFns).then(
            () => {
                console.log("Done DB Setup");
                resolve();
            }
        ).catch(
            (err) => {
                console.log(`setupDb Error: ${err}`);
                resolve();
            }
        )
    });
}

module.exports = {
    setupDb
}