
$(function () {
    var testEditor = editormd("test-editor", {
        width: "100%",
        height: "700",
        path: "libs/editor.md/lib/",
        theme: "dark",
        previewTheme: "dark",
        editorTheme: "pastel-on-dark",
        //markdown: md,
        codeFold: true,
        emoji: true,
        watch: false,
    });
    $('#showMarkdown').click(() => {
        alert(testEditor.getMarkdown());
        testEditor.fullscreen();
    }
    )
});
