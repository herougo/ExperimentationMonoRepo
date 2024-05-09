const { User } = require('../models/user_model.js');
const { dbRunPromise } = require('../database.js');

class UserRepository {
    constructor(db) {
        this._db = db;
    }

    create(user) {
        const sqlStatement = `
            INSERT INTO Users(username, password)
            VALUES (?, ?)
            RETURNING *;`
        return new Promise((resolve, reject) => {
            this._db.get(
                sqlStatement, 
                [user.username, user.password], 
                (err, row) => {
                    if (err) {
                        reject(err);
                    } else {
                        resolve(User.fromRow(row));
                    }
                }
            );
        });
    }

    update(user) {
        const sqlStatement = `
            UPDATE Users
            SET
                username = ?,
                password = ?
            WHERE id = ?;`
        return dbRunPromise(
            this._db, sqlStatement,
            [user.username, user.password, user.id]
        );
    }

    delete(user) {
        const sqlStatement = `
            DELETE FROM Users
            WHERE id = ?;`
        return dbRunPromise(
            this._db, sqlStatement,
            user.id
        );
    }

    findOne(userId) {
        const sqlStatement = `
            SELECT * FROM Users
            WHERE id = ?;`
        return new Promise((resolve, reject) => {
            this._db.get(sqlStatement, userId, (err, row) => {
                if (err) {
                    reject(err);
                } else {
                    resolve(User.fromRow(row));
                }
            });
        });
    }
}

module.exports = {
    UserRepository
}