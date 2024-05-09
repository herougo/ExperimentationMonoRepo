class Task {
    constructor (id, epicId, title, description, status, dateCompleted) {
        this.id = id;
        this.epicId = epicId;
        this.title = title;
        this.description = description;
        this.status = status;
        this.dateCompleted = dateCompleted;
    }

    static fromRow(row) {
        return Epic(
            row.id, row.epic_id, row.title, row.description, 
            row.status, row.date_completed
        );
    }
}

module.exports = {
    Task
}