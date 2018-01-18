var ExtractTextPlugin = require('extract-text-webpack-plugin');
const path = require('path');

module.exports = {
    module: {
        rules: [
            {
                test: /\.vue$/,
                use: {
                    loader: 'vue-loader',
                    options: {
                        loaders: {
                            scss: ExtractTextPlugin.extract({
                                fallback: 'style-loader', // The backup style loader
                                use: ['css-loader', 'sass-loader']
                            }), 
                            css: ExtractTextPlugin.extract({
                                use: 'css-loader',
                                fallback: 'vue-style-loader'
                            })
                        }
                      }
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
                test: /\.css$/,
                use: ExtractTextPlugin.extract({
                    fallback: 'style-loader', // The backup style loader
                    use: 'css-loader'
                }),
            },{
                test: /\.scss$/,
                use: ExtractTextPlugin.extract({
                    fallback: 'style-loader', // The backup style loader
                    use: ['css-loader', 'sass-loader']
                }),
            }
        ]
    },
    resolve: {
        alias: {
            'vue$': 'vue/dist/vue.js', // 'vue/dist/vue.common.js' for webpack 1
            'Components': path.resolve(__dirname, 'Components/'),
            'Utils': path.resolve(__dirname, 'Scripts/Utils/')
        }
    },
    entry: './Scripts/main.js',
    output: {
        path: path.resolve(__dirname, './dist'),
        publicPath: '/dist/',
        filename: 'bundle.js'
    },
    plugins: [
        new ExtractTextPlugin('style.css')
    ]
};