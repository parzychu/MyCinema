
const path = require('path');

module.exports = {
    entry: './Scripts/main.js',
    output: {
        path: path.resolve(__dirname, './dist'),
        filename: 'bundle.js'
    }
};