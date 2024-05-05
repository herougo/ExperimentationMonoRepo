const { getFilePaths } = require('./path_utils.js');
const { readFile } = require('./file_utils.js');

function getDbMigrationsInOrder() {
    const migrationFilePaths = getFilePaths(__dirname, 'db', 'migrations');
    migrationFilePaths.sort();
    return migrationFilePaths;
}

function getDbDataPopulationFilesInOrder() {
    const populationFilePaths = getFilePaths(__dirname, 'db', 'data-population');
    populationFilePaths.sort();
    return populationFilePaths;
}

async function setupDb(version) {
    const migrationFilePaths = getDbMigrationsInOrder();
    const populationFilePaths = getDbDataPopulationFilesInOrder();
    try {
        await runStatementsSerial(db, migrationFilePaths.map(path => readFile(path)));
        await runStatementsSerial(db, populationFilePaths.map(path => readFile(path)));
    } catch (error) {
        console.log(`Error: ${error}`);
    }
}

module.exports = {
    setupDb
}