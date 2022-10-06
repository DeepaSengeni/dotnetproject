/**
 * @license Copyright (c) 2003-2021, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	config.uiColor = '#AADC6E';
	config.height = '750px';
	config.height = 300;
	config.toolbarCanCollapse = true;
	allowedContent = true;

	plugins: 'MyPlugin';
	filebrowserBrowseUrl: 'ckeditor1/ckfinder/ckfinder.html';
	filebrowserImageBrowseUrl: 'ckeditor1/ckfinder/ckfinder.html?type=Images';
	filebrowserUploadUrl: 'ckeditor1/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Files';
	filebrowserImageUploadUrl: 'ckeditor1/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Images';
		
	/*config.extraPlugins = 'imageuploader', 'embed', 'video', 'ckeditor_wiris';*/
	config.extraPlugins = "ckeditor_wiris ,FMathEditor,video,uploadimage,filebrowser,image,videoembed,pastebase64,soundPlayer,audio,ckwebspeech,image";
	CKEDITOR.plugins.addExternal('ckeditor_wiris', 'https://www.wiris.net/demo/plugins/ckeditor/', 'plugin.js');
	config.toolbar = [
		{ name: 'document', groups: ['mode', 'document', 'doctools'], items: ['Source', '-', 'Save', 'NewPage', 'ExportPdf', 'Preview', 'Print', '-', 'Templates'] },
		{ name: 'clipboard', groups: ['clipboard', 'undo'], items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
		{ name: 'editing', groups: ['find', 'selection', 'spellchecker'], items: ['Find', 'Replace', '-', 'SelectAll', '-', 'Scayt'] },
		{ name: 'forms', items: ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField'] },
		'/',
		{ name: 'basicstyles', groups: ['basicstyles', 'cleanup'], items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'CopyFormatting', 'RemoveFormat'] },
		{ name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'], items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', 'CreateDiv', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl', 'Language'] },
		{ name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
		{ name: 'insert', items: ['Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe'] },
		'/',
		{ name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
		{ name: 'colors', items: ['TextColor', 'BGColor'] },
		{ name: 'tools', items: ['Maximize', 'ShowBlocks'] },
		{ name: 'others', items: ['-'] },
		{ name: 'about', items: ['About'] },
		{ name: 'wirisplugins', items: ['ckeditor_wiris_formulaEditor', 'ckeditor_wiris_formulaEditorChemistry', 'FMathEditor'] },
		{ name: 'Video', items: ['Video', 'uploadimage', 'VideoEmbed', 'soundPlayer', 'Audio', 'webSpeechEnabled','Image'] }
	];

	// Toolbar groups configuration.
	config.toolbarGroups = [
		{ name: 'document', groups: ['mode', 'document', 'doctools'] },
		{ name: 'clipboard', groups: ['clipboard', 'undo'] },
		{ name: 'editing', groups: ['find', 'selection', 'spellchecker'] },
		{ name: 'forms' },
		'/',
		{ name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
		{ name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'] },
		
		{ name: 'links' },
		{ name: 'insert' },
		'/',
		{ name: 'styles' },
		{ name: 'colors' },
		{ name: 'tools' },
		{ name: 'others' },
		{ name: 'about' }
	];
};


