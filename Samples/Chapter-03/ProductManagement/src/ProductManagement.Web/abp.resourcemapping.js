module.exports = {
    aliases: {

    },
    mappings: {
        // Copy all sub-directories
        "@node_modules/editor.md/css/**": "@libs/editor.md/css/",
        "@node_modules/editor.md/lib/**": "@libs/editor.md/lib/",
        "@node_modules/editor.md/editor*.js": "@libs/editor.md/js/"
    }
};
