const path = require('path');
const fs = require('fs');

function getFilePaths(dirPath) {
    const files = fs.readdirSync(dirPath);
    return files.map(fileName => path.join(dirPath, fileName));
}

module.exports = {
    getFilePaths
}