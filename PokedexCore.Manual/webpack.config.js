"use strict";

var WebpackNotifierPlugin = require('webpack-notifier');
var Path = require('path');

module.exports = {
    entry: "./ClientApp/root.tsx",
    output: {
        filename: "./wwwroot/js/bundle.js"
    },
    resolve: {
        modules: [
            Path.resolve('./node_modules')
        ],
        // возможно стоит добавить пустое "" расширение в extenstions 
        extensions: [".webpack.js", ".web.js", ".js", ".json", ".jsx", ".ts", ".tsx"]
    },
    module: {
        loaders: [
            {
                test: /\.ts?$/,
                loader: "ts-loader",
                exclude: /node_modules/,
            },
            {
                test: /\.tsx?$/,
                loader: "ts-loader",
                exclude: /node_modules/,
            },
        ]
    },
    plugins: [
        new WebpackNotifierPlugin()
    ]
};