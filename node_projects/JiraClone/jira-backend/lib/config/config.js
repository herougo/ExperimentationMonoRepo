const path = require("path");

const configFolder = __dirname;
const jiraBackendFolder = path.join(configFolder, '..', '..');
const outputFolder = path.join(jiraBackendFolder, 'output');

const databaseConfig = {
    production: {
        filePath: path.join(outputFolder, 'prod_database.db')
    },
    test: {
        filePath: path.join(outputFolder, 'test_database.db')
    }
}

const envVar = {
    nodeEnv: process.env.NODE_ENV
}

module.exports = {
    databaseConfig, envVar
};