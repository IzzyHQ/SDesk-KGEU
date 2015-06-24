/// <reference path="~/GeneratedArtifacts/viewModel.js" />


myapp.AddEditFileItem.Image_render = function (element, contentItem) {
    createImageUploader(element, contentItem, "max-width: 300px; max-height: 300px");
};


myapp.AddEditFileItem.beforeApplyChanges = function (screen) {
    var filename = $('input[type=file]').val().replace(/.*(\/|\\)/, '');
    screen.FileItem.FileName = filename;
};