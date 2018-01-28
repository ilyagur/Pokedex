"use strict";

var WebpackNotifierPlugin = require('webpack-notifier');
var Path = require('path');

module.exports = {
    entry: "./ClientApp/root.jsx",
    output: {
        filename: "./wwwroot/js/bundle.js"
    },
    resolve: {
        modules: [
            Path.resolve('./node_modules')
        ],
        // возможно стоит добавить пустое "" расширение в extenstions 
        extensions: [".webpack.js", ".web.js", ".js", ".json", ".jsx"]
    },
    module: {
        loaders: [
            {
                test: /\.js$/,
                exclude: /node_modules/,
                loaders: ['babel-loader', 'eslint-loader']
            },
            {
                test: /\.jsx?$/,
                loader: "babel-loader",
                query: {
                    presets: ['es2015', 'react']
                }
            }
        ]
    },
    plugins: [
        new WebpackNotifierPlugin()
    ]
};