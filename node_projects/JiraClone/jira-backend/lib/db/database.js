const sqlite3 = require('sqlite3');
const { databaseConfig, envVar } = require('../config/config.js')

let db = null;

function getDatabase(version) {
    version = version || envVar.nodeEnv;
    const dbConfig = databaseConfig[version];
    const dbFilePath = dbConfig.filePath;
    db = db || new sqlite3.Database(dbFilePath);
    return db;
}

module.exports = {
    getDatabase
}