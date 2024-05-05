function dbRun(db, statement) {
    return new Promise((resolve, reject) => {
        db.run(statement, (err) => {
            if (err) {
                reject(err); 
            } else {
                resolve();
            }
        });
    });
}

function runStatementsSerial(db, statements) {
    return new Promise(function(resolve, reject) {
        db.serialize(async () => {
            try {
                for (const [i, statement] of statements.entries()) {
                    await dbRun(db, statement);
                    console.log(`Completed statement ${i}`)
                }
                resolve();
            } catch (error) {
                reject(error);
            }
        });
    });
}