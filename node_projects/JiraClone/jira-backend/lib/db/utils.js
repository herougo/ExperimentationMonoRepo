const { dbRunPromise } = require('../../lib/db/database.js')

function runStatementsSerial(db, statements) {
    return new Promise(function(resolve, reject) {
        db.serialize(() => {
            let promises = [];
            for (const statement of statements) {
                promises.push(dbRunPromise(db, statement));
            }
            Promise.all(promises).then(
                () => resolve()
            ).catch(
                (err) => reject(err)
            );
        });
    });
}

module.exports = {
    runStatementsSerial
}