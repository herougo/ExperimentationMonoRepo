const { Epic } = require('../models/epic_model.js');
const { dbRunPromise } = require('../database.js');

class EpicRepository {
    constructor(db) {
        this._db = db;
    }

    create(epic) {
        const sqlStatement = `
            INSERT INTO Epics(user_id, title, description)
            VALUES (?, ?, ?)
            RETURNING *;`
        return new Promise((resolve, reject) => {
            this._db.get(
                sqlStatement, 
                [epic.userId, epic.title, epic.description], 
                (err, row) => {
                    if (err) {
                        reject(err);
                    } else {
                        resolve(Epic.fromRow(row));
                    }
                }
            );
        });
    }

    update(epic) {
        const sqlStatement = `
            UPDATE Epics
            SET
                user_id = ?,
                title = ?,
                description = ?
            WHERE id = ?;`
        return dbRunPromise(
            this._db, sqlStatement,
            [epic.userId, epic.title, epic.description, epic.id]
        );
    }

    delete(epic) {
        const sqlStatement = `
            DELETE FROM Epics
            WHERE id = ?;`
        return dbRunPromise(
            this._db, sqlStatement,
            user.id
        );
    }

    findOne(epicId) {
        const sqlStatement = `
            SELECT * FROM Epics
            WHERE id = ?;`
        return new Promise((resolve, reject) => {
            this._db.get(sqlStatement, epicId, (err, row) => {
                if (err) {
                    reject(err);
                } else {
                    resolve(Epic.fromRow(row));
                }
            });
        });
    }
}

module.exports = {
    EpicRepository
}