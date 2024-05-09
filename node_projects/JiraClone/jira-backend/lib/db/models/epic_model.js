class Epic {
    constructor (id, userId, title, description) {
        this.id = id;
        this.userId = userId;
        this.title = title;
        this.description = description;
    }

    static fromRow(row) {
        return Epic(row.id, row.user_id, row.title, row.description);
    }
}

module.exports = {
    Epic
}