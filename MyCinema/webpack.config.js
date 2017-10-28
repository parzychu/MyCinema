var ExtractTextPlugin = require('extract-text-webpack-plugin');
const path = require('path');

module.exports = {
    module: {
        rules: [
            {
                test: /\.vue$/,
                use: {
                    loader: 'vue-loader'
                }
            },
            {
                test: /\.js$/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: ['env']
                    }
                }
            }, {
            }, {
                test: /\.scss$/,
//                use: [{
//                    loader: "style-loader" // creates style nodes from JS strings
//                }, {
//                        loader: "css-loader", options: {
//                        sourceMap: true
//                    } // translates CSS into CommonJS
//                }, {
//                        loader: "sass-loader", options: {
//                        sourceMap: true
//                    } // compiles Sass to CSS
//                }],
                loader: ExtractTextPlugin.extract(
                    'style', // The backup style loader
                    'css?sourceMap!sass?sourceMap'
                ),
            }
        ]
    },
    resolve: {
        alias: {
            'vue$': 'vue/dist/vue.js', // 'vue/dist/vue.common.js' for webpack 1
            'Components': path.resolve(__dirname, 'Components/')
        }
    },
    entry: './Scripts/main.js',
    output: {
        path: path.resolve(__dirname, './dist'),
        publicPath: '/dist/',
        filename: 'bundle.js'
    },
    plugins: [
        new ExtractTextPlugin('./dist/style.css')
    ]
};