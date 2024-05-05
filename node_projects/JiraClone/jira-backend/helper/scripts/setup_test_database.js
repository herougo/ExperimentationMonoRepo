const { Envs } = require('../../lib/config/enums');
const { getDatabase } = require('../../lib/db/database.js');
const { setupDb } = require('../utils/db_utils.js')


let db = getDatabase(Envs.TEST);
setupDb(db).then(() => {
    db.all('SELECT * FROM Users;', [], (err, rows) => {
        if (err) {
            console.log(err);
            db.close();
            return;
        }
        rows.forEach((row) => {
            console.log(row);
        });
        db.close();
    });
});