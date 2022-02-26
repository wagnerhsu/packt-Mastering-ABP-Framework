module.exports = {
    aliases: {

    },
    mappings: {
        // Copy all sub-directories
        "@node_modules/editor.md/css/**": "@libs/editor.md/css/",
        "@node_modules/editor.md/lib/**": "@libs/editor.md/lib/",
        "@node_modules/editor.md/editor*.js": "@libs/editor.md/js/",
        "@node_modules/editor.md/fonts/**": "@libs/editor.md/fonts/",
        "@node_modules/editor.md/images/**": "@libs/editor.md/images/",
        "@node_modules/editor.md/plugins/**": "@libs/editor.md/plugins/",
        "@node_modules/editor.md/languages/**": "@libs/editor.md/languages/",
    }
};
