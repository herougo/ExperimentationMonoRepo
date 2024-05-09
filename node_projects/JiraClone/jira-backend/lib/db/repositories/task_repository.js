const { Task } = require('../models/task_model.js');
const { dbRunPromise } = require('../database.js');

class TaskRepository {
    constructor(db) {
        this._db = db;
    }

    create(task) {
        const sqlStatement = `
            INSERT INTO Tasks(epic_id, title, description, status, date_completed)
            VALUES (?, ?, ?, ?, ?)
            RETURNING *;`
        return new Promise((resolve, reject) => {
            this._db.get(
                sqlStatement, 
                [
                    task.epicId, task.title, task.description, 
                    task.status, task.dateCompleted
                ], 
                (err, row) => {
                    if (err) {
                        reject(err);
                    } else {
                        resolve(Task.fromRow(row));
                    }
                }
            );
        });
    }

    update(task) {
        const sqlStatement = `
            UPDATE Tasks
            SET
                epic_id = ?,
                title = ?,
                description = ?,
                status = ?,
                date_completed = ?
            WHERE id = ?;`
        return dbRunPromise(
            this._db, sqlStatement,
            [
                task.epicId, task.title, task.description, 
                task.status, task.dateCompleted, task.id
            ]
        );
    }

    delete(task) {
        const sqlStatement = `
            DELETE FROM Tasks
            WHERE id = ?;`
        return dbRunPromise(
            this._db, sqlStatement,
            task.id
        );
    }

    findOne(taskId) {
        const sqlStatement = `
            SELECT * FROM Tasks
            WHERE id = ?;`
        return new Promise((resolve, reject) => {
            this._db.get(sqlStatement, taskId, (err, row) => {
                if (err) {
                    reject(err);
                } else {
                    resolve(Task.fromRow(row));
                }
            });
        });
    }
}

module.exports = {
    TaskRepository
}