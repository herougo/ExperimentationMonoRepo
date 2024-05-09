class User {
    constructor (id, username, password) {
        this.id = id;
        this.username = username;
        this.password = password;
    }

    static fromRow(row) {
        return new User(row.id, row.username, row.password);
    }
}

module.exports = {
    User
}