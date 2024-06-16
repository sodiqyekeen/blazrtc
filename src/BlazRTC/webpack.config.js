const path = require('path');

module.exports = {
    entry: './wwwroot/js/blazrtc/blazrtc.js',
    output: {
        filename: 'blazrtc.bundle.js',
        path: path.resolve(__dirname, 'wwwroot')
    },
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: ['@babel/preset-env']
                    }
                }
            }
        ]
    }
}