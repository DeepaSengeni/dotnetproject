var Index = function () {
    M.trustHtml = true;
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');
    var txtbox = $('#mathSrc1')[0];
    var powerTextbox = $('#powerTextbox')[0];

    
    return {

        init: function () {
            editor.attr('contenteditable', 'true');
        },
        initKeyboard: function () {
            defaultScientific_KeyBoard();
        },
        attachEvent: function () {

            $(document).on('click', 'span.KeyboardKey', function () {
                var index = parseInt($(this).attr('data-attr'));
                switch (index) {
                    case 1:
                        gotoXbyy();
                        break;
                    case 2:
                        gotoxpowerybasez();
                        break;
                    case 3:
                        gotorootasquarePlusbSquare();
                        break;
                    case 4:
                        gotoDifferentiationOfwithRespecttoX();
                        break;
                    case 5:
                        gotoIntegrationWithLimit();
                        break;
                    case 6:
                        gotoBrackets();
                        break;
                    case 11:
                        gotoSummation();
                        break;
                    case 12:
                        gotoForAllSym();
                        break;
                    case 16:
                        
                        // editor.append(doMathSrc("x/y"));
                        var trust = txtbox.value + '/' + txtbox.value;
                        AddTextBox(trust);
                        break;
                    case 17:
                        var trust = "∏" + '/' + txtbox.value;
                        AddTextBox(trust);
                        //editor.append(doMathSrc("∏/2"));
                        break;
                    case 18:
                        // editor.append(doMathSrc("x^y"));
                        var trust = txtbox.value + '^' + txtbox.value;
                        AddTextBox(trust);
                        break;
                    case 19:
                        //editor.append(doMathSrc("x_z"));
                        var trust = txtbox.value + '_' + txtbox.value;
                        AddTextBox(trust);
                        break;
                    case 20:
                        var trust = txtbox.value + '^' + powerTextbox.value + '_' + powerTextbox.value;
                        AddTextBox(trust);
                        // editor.append(doMathSrc("x^y_z"));
                        break;
                    case 21:
                        var trust = txtbox.value + '^' + txtbox.value;
                        AddTextBox(trust);

                        //editor.append(doMathSrc("x^2"));
                        break;
                    case 22:
                        var trust = txtbox.value + '_' + powerTextbox.value + '^' + powerTextbox.value;
                        AddTextBox(trust);
                        // editor.append(doMathSrc("x_y^2"));
                        break;
                    case 23:
                       
                        editor.append(doMathSrc("e^{-tiθ}"));
                        break;
                    case 24:
                        var trust = '√{' + txtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("√{a}"));
                        break;
                    case 25:
                        var trust = '√^' +  powerTextbox.valu + '{' + txtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("√^n{a}"));
                        break;
                    case 26:
                        var trust = '√^2{' + txtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("√^2{a}"));
                        break;
                    case 27:
                        var trust = '√^3{' + txtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("√^3{a}"));
                        break;
                    case 28:
                        var trust = '{-' + txtbox.value + '±√{' + txtbox.value + '^' + powerTextbox.value + '-4' + txtbox.value + '}}/{2' + txtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("{-b±√{b^2-4ac}}/{2a}"));
                        break;
                    case 29:
					 var trust = '√{' + txtbox.value + '^' + powerTextbox.value + '+' + txtbox.value + '^' + powerTextbox.value + '}';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("√{a^2+b^2}"));
                        break;
                    case 30:
					var trust = '{' + txtbox.value + '}/{' + txtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("{dy}/{dx}"));
                        break;
                    case 31:
					var trust = '{' + txtbox.value + '}/{' + txtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("{△y}/{△x}"));
                        break;
                    case 32:
					var trust = '{' + txtbox.value + '}/{' + txtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("{∂y}/{∂x}"));
                        break;
                    case 33:
					var trust = '{' + txtbox.value + '}/{' + txtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("{δy}/{δx}"));
                        break;
                    case 34:
					var trust = '∫' + txtbox.value + '';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("∫x"));
                        break;
                    case 35:
					var trust = '∫↙{-' + powerTextbox.value + '}↖{' + powerTextbox.value + '}' + txtbox.value + '';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("∫↙{-x}↖{x}x"));
                        break;
                    case 36:
					var trust = '∫∫' + txtbox.value + '';
                        AddTextBox(trust);
                       // editor.append(doMathSrc("∫∫x"));
                        break;
                    case 37:
						var trust = '∫∫↙{-' + powerTextbox.value + '}↖{' + powerTextbox.value + '}' + txtbox.value + '';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("∫∫↙{-x}↖{x}x"));
                        break;
                    case 38:
					var trust = '∫∫∫↙{-' + powerTextbox.value + '}↖{' + powerTextbox.value + '}' + txtbox.value + '';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("∫∫∫↙{-x}↖{x}x"));
                        break;
                    case 39:
					var trust = '∫∫∫' + txtbox.value + '';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("∫∫∫x"));
                        break;
                    case 40:
					var trust = '∫∫∫↙{-' + powerTextbox.value + '}↖{' + powerTextbox.value + '}' + txtbox.value + '';
                        AddTextBox(trust);
                       // editor.append(doMathSrc("∫∫∫↙{-x}↖{x}x"));
                        break;
                    case 41:
					var trust = '∫∫∫↙{-' + powerTextbox.value + '}↖{' + powerTextbox.value + '}' + txtbox.value + '';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("∫∫∫↙{-x}↖{x}x"));
                        break;
                    case 42:
					var trust = '∮' + txtbox.value + '';
                        AddTextBox(trust);
                       // editor.append(doMathSrc("∮x"));
                        break;
                    case 43:
					var trust = '∮↙{-' + powerTextbox.value + '}↖{' + powerTextbox.value + '}' + txtbox.value + '';
                        AddTextBox(trust);
                       // editor.append(doMathSrc("∮↙{-x}↖{x}x"));
                        break;
                    case 44:
					var trust = '∮↙{-' + powerTextbox.value + '}↖{' + powerTextbox.value + '}' + txtbox.value + '';
                        AddTextBox(trust);
                       // editor.append(doMathSrc("∮↙{-x}↖{x}x"));
                        break;
                    case 45:
					var trust = '∯' + txtbox.value + '';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("∯x"));
                        break;
                    case 46:
					var trust = '∯↙{-' + powerTextbox.value + '}↖{' + powerTextbox.value + '}' + txtbox.value + '';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("∯↙{-x}↖{x}x"));
                        break;
                    case 47:
						var trust = '∯↙{-' + powerTextbox.value + '}↖{' + powerTextbox.value + '}' + txtbox.value + '';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("∯↙{-x}↖{x}x"));
                        break;
                    case 48:
					var trust = '∯' + txtbox.value + '';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("∰x"));
                        break;
                    case 49:
						var trust = '∯↙{-' + powerTextbox.value + '}↖{' + powerTextbox.value + '}' + txtbox.value + '';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("∰↙{-x}↖{x}x"));
                        break;
                    case 50:
					var trust = '∯↙{-' + powerTextbox.value + '}↖{' + powerTextbox.value + '}' + txtbox.value + '';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("∰↙{-x}↖{x}x"));
                        break;
                    case 51:
					var trust = '(' + txtbox.value + ')';
                        AddTextBox(trust);
                        //editor.append("()");
                        break;
                    case 52:
					var trust = '{' + txtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append("{}");
                        break;
                    case 53:
					var trust = '[' + txtbox.value + ']';
                        AddTextBox(trust);
                        //editor.append("[]");
                        break;
                    case 54:
					var trust = '<' + txtbox.value + '>';
                        AddTextBox(trust);
                       // editor.append("<>");
                        break;
                    case 55:
					var trust = '(' + txtbox.value + '|' + txtbox.value + ')';
                        AddTextBox(trust);
                        //editor.append("(|)");
                        break;
                    case 56:
					var trust = '{' + txtbox.value + '|' + txtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append("{|}");
                        break;
                    case 57:
					var trust = '[' + txtbox.value + '|' + txtbox.value + ']';
                        AddTextBox(trust);
                        //editor.append("[|]");
                        break;
                    case 58:
					var trust = '<' + txtbox.value + '|' + txtbox.value + '>';
                        AddTextBox(trust);
                        //editor.append("<|>");
                        break;
                    case 59:
                        editor.append(doMathSrc("\\{\\table x;y;"));
                        break;
                    case 60:
                        editor.append(doMathSrc("\\{\\table x;y;z;"));
                        break;
                    case 61:
                        editor.append(doMathSrc("\\table x;y;"));
                        break;
                    case 62:
                        editor.append(doMathSrc("(\\table x;y;)"));
                        break;
                    case 63:
                        editor.append(doMathSrc("(\\table m; ;k;)"));
                        break;
                    case 64:
                        editor.append(doMathSrc("f(x)=\\{\\table -x,x&lt;0;x,x⋝0;\\}"));
                        break;
                    case 65:
					var trust = '∑' + txtbox.value + '';
                        AddTextBox(trust);
                       // editor.append(doMathSrc("∑x"));
                        break;
                    case 66:
					var trust = '∑↙{' + powerTextbox.value + '}↖' + powerTextbox.value + '';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("∑↙{n}↖n"));
                        break;
                    case 67:
					var trust = '∑↙{' + powerTextbox.value + '}↖' + powerTextbox.value + '{' + txtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("∑↙{n}↖n{x}"));
                        break;
                    case 68:
					var trust = '∑↙{' + powerTextbox.value + '}{' + txtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("∑↙{n}{x}"));
                        break;
                    case 69:
					var trust = '∑↙{' + powerTextbox.value + '}(\\table ' + txtbox.value + ';' + txtbox.value + ')';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("∑↙{k}(\\table n;k)"));
                        break;
                    case 70:
					var trust = '∑↙{i=0}↖' + powerTextbox.value + '{' + txtbox.value + '}';
                        AddTextBox(trust);
                       // editor.append(doMathSrc("∑↙{i=0}↖n{x}"));
                        break;
                    case 71:
					var trust = '∑↙{0⋜i⋜' + powerTextbox.value + '}↙{0⋜j⋜' + powerTextbox.value + '}↖' + powerTextbox.value + '{P(' + txtbox.value + ',' + txtbox.value + ')}';
                        AddTextBox(trust);
                       // editor.append(doMathSrc("∑↙{0⋜i⋜m}↙{0⋜j⋜m}↖n{P(i,j)}"));
                        break;
                    case 72:
					var trust = '⋁' + txtbox.value + '';
                        AddTextBox(trust);
                       // editor.append(doMathSrc("⋁x"));
                        break;
                    case 73:
					var trust = '⋁↙{-' + powerTextbox.value + '}↖{' + powerTextbox.value + '}{' + txtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("⋁↙{-x}↖{x}{y}"));
                        break;
                    case 74:
					var trust = '⋁↖{' + powerTextbox.value + '}{' + txtbox.value + '}';
                        AddTextBox(trust);
                       // editor.append(doMathSrc("⋁↖{x}{y}"));
                        break;
                    case 75:
					var trust = '⋀' + txtbox.value + '';
                        AddTextBox(trust);
                       // editor.append(doMathSrc("⋀x"));
                        break;
                    case 76:
					var trust = '⋀↙{-' + powerTextbox.value + '}↖{' + powerTextbox.value + '}{' + txtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("⋀↙{-x}↖{x}{y}"));
                        break;
                    case 77:
					var trust = '⋀↖{' + powerTextbox.value + '}{' + txtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("⋀↖{x}{y}"));
                        break;
                }
            });


        }
    };


}();
var ents_ = { nwarr: '\u2196', swarr: '\u2199' };
function gotoXbyy() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [
       '<div class="keyboard" data-attr="SCIENTIFIC_MAIN">',
       '<div class="KeyboardRow">',
       '<span class="KeyboardKey" data-attr="16">' + doMathSrc("x/y").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="17">' + doMathSrc("∏/2").outerHTML + '</span>',
       '</div>',
       '</div>'
    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
    leftMenu.empty();
    leftMenu.append('<span>' + doMathSrc("x/y").outerHTML + '</span>');
    leftMenu.append('<span onclick="return defaultScientific_KeyBoard();">SK</span>');
    leftMenu.append('<span onclick="return gotoQWETY();">QK</span>');

}

function gotoxpowerybasez() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [
       '<div class="keyboard" data-attr="SCIENTIFIC_MAIN">',
       '<div class="KeyboardRow">',
       '<span class="KeyboardKey" data-attr="18">' + doMathSrc("x^y").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="19">' + doMathSrc("x_z").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="20">' + doMathSrc("x^y_z").outerHTML + '</span>',
       '</div>',
       '<div class="KeyboardRow">',
       '<span class="KeyboardKey" data-attr="21">' + doMathSrc("x^2").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="22">' + doMathSrc("x_y^2").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="23">' + doMathSrc("e^{-tiθ}").outerHTML + '</span>',
       '</div>',
       '</div>'
    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
    leftMenu.empty();
    leftMenu.append('<span>' + doMathSrc("x^y_z").outerHTML + '</span>');
    leftMenu.append('<span onclick="return defaultScientific_KeyBoard();">SK</span>');
    leftMenu.append('<span onclick="return gotoQWETY();">QK</span>');
}

function gotorootasquarePlusbSquare() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [
      '<div class="keyboard" data-attr="SCIENTIFIC_MAIN">',
      '<div class="KeyboardRow">',
      '<span class="KeyboardKey" data-attr="24">' + doMathSrc("√{a}").outerHTML + '</span>',
      '<span class="KeyboardKey" data-attr="25">' + doMathSrc("√^n{a}").outerHTML + '</span>',
      '<span class="KeyboardKey" data-attr="26">' + doMathSrc("√^2{a}").outerHTML + '</span>',
      '<span class="KeyboardKey" data-attr="27">' + doMathSrc("√^3{a}").outerHTML + '</span>',
      '</div>',
      '<div class="KeyboardRow">',
      '<span class="KeyboardKey" data-attr="28">' + doMathSrc("{-b±√{b^2-4ac}}/{2a}").outerHTML + '</span>',
      '<span class="KeyboardKey" data-attr="29">' + doMathSrc("√{a^2+b^2}").outerHTML + '</span>',
      '</div>',
      '</div>'
    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
    leftMenu.empty();
    leftMenu.append('<span>' + doMathSrc("√^n{a^p+b^q}").outerHTML + '</span>');
    leftMenu.append('<span onclick="return defaultScientific_KeyBoard();">SK</span>');
    leftMenu.append('<span onclick="return gotoQWETY();">QK</span>');
}

function gotoDifferentiationOfwithRespecttoX() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [
       '<div class="keyboard" data-attr="SCIENTIFIC_MAIN">',
       '<div class="KeyboardRow">',
       '<span class="KeyboardKey" data-attr="30">' + doMathSrc("{dy}/{dx}").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="31">' + doMathSrc("{△y}/{△x}").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="32">' + doMathSrc("{∂y}/{∂x}").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="33">' + doMathSrc("{δy}/{δx}").outerHTML + '</span>',
       '</div>',
       '</div>'
    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
    leftMenu.empty();
    leftMenu.append('<span>' + doMathSrc("{dy}/{dx}").outerHTML + '</span>');
    leftMenu.append('<span onclick="return defaultScientific_KeyBoard();">SK</span>');
    leftMenu.append('<span onclick="return gotoQWETY();">QK</span>');
}

function gotoIntegrationWithLimit() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [
       '<div class="keyboard" data-attr="SCIENTIFIC_MAIN">',
       '<div class="KeyboardRow">',
       '<span class="KeyboardKey" data-attr="34">' + doMathSrc("∫x").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="35">' + doMathSrc("∫↙{-x}↖{x}x").outerHTML + '</span>',
       '<div class="KeyboardRow">',
       '<span class="KeyboardKey" data-attr="36">' + doMathSrc("∫∫x").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="37">' + doMathSrc("∫∫↙{-x}↖{x}x").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="38">' + doMathSrc("∫∫∫↙{-x}↖{x}x").outerHTML + '</span>',
       '</div>',
       '</div>',
       '</div>'
    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
    leftMenu.empty();
    leftMenu.append('<span>' + doMathSrc("∫↙{-x}↖{x}").outerHTML + '</span>');
    leftMenu.append('<span onclick="return defaultScientific_KeyBoard();">SK</span>');
    leftMenu.append('<span onclick="return gotoQWETY();">QK</span>');
    rightMenu.empty();
    rightMenu.append('<span class="integrationClass" onclick="return gotoIntegrationWithLimitextra();">' + doMathSrc("▶").outerHTML + '</span>');

}

function gotoIntegrationWithLimitextra() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [
       '<div class="keyboard" data-attr="SCIENTIFIC_MAIN">',
       '<div class="KeyboardRow">',
       '<span class="KeyboardKey" data-attr="39">' + doMathSrc("∫∫∫x").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="40">' + doMathSrc("∫∫∫↙{-x}↖{x}x").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="41">' + doMathSrc("∫∫∫↙{-x}↖{x}x").outerHTML + '</span>',
       '<div class="KeyboardRow">',
       '<span class="KeyboardKey" data-attr="42">' + doMathSrc("∮x").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="43">' + doMathSrc("∮↙{-x}↖{x}x").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="44">' + doMathSrc("∮↙{-x}↖{x}x").outerHTML + '</span>',
       '</div>',
       '</div>',
       '</div>'
    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
    leftMenu.empty();
    leftMenu.append('<span>' + doMathSrc("∫↙{-x}↖{x}").outerHTML + '</span>');
    leftMenu.append('<span onclick="return defaultScientific_KeyBoard();">SK</span>');
    leftMenu.append('<span onclick="return gotoQWETY();">QK</span>');
    leftMenu.append('<span onclick="return gotoIntegrationWithLimit();">' + doMathSrc("◀").outerHTML + '</span>');
    rightMenu.empty();
    leftMenu.append('<span onclick="return gotoIntegrationWithLimitextraExtra();">' + doMathSrc("▶").outerHTML + '</span>');

}

function gotoIntegrationWithLimitextraExtra() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [
       '<div class="keyboard" data-attr="SCIENTIFIC_MAIN">',
       '<div class="KeyboardRow">',
       '<span class="KeyboardKey" data-attr="45">' + doMathSrc("∯x").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="46">' + doMathSrc("∯↙{-x}↖{x}x").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="47">' + doMathSrc("∯↙{-x}↖{x}x").outerHTML + '</span>',
       '<div class="KeyboardRow">',
       '<span class="KeyboardKey" data-attr="48">' + doMathSrc("∰x").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="49">' + doMathSrc("∰↙{-x}↖{x}x").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="50">' + doMathSrc("∰↙{-x}↖{x}x").outerHTML + '</span>',
       '</div>',
       '</div>',
       '</div>'
    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
    leftMenu.empty();
    leftMenu.append('<span>' + doMathSrc("∫↙{-x}↖{x}").outerHTML + '</span>');
    leftMenu.append('<span onclick="return defaultScientific_KeyBoard();">SK</span>');
    leftMenu.append('<span onclick="return gotoIntegrationWithLimitextra();">' + doMathSrc("◀").outerHTML + '</span>');
    leftMenu.append('<span onclick="return gotoQWETY();">QK</span>');
    rightMenu.empty();

}

function gotoBrackets() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [
       '<div class="keyboard" data-attr="SCIENTIFIC_MAIN">',
       '<div class="KeyboardRow">',
       '<span class="KeyboardKey" data-attr="51">()</span>',
       '<span class="KeyboardKey" data-attr="52">{}</span>',
       '<span class="KeyboardKey" data-attr="53">[]</span>',
       '<span class="KeyboardKey" data-attr="54"><></span>',
       '<div class="KeyboardRow">',
       '<span class="KeyboardKey" data-attr="55">(|)</span>',
       '<span class="KeyboardKey" data-attr="56">{|}</span>',
       '<span class="KeyboardKey" data-attr="57">[|]</span>',
       '<span class="KeyboardKey" data-attr="58"><|></span>',
       '</div>',
       '</div>',
       '</div>'
    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
    leftMenu.empty();
    leftMenu.append('<span>' + doMathSrc("[{()}]").outerHTML + '</span>');
    leftMenu.append('<span onclick="return defaultScientific_KeyBoard();">SK</span>');
    rightMenu.empty();
    rightMenu.append('<span onclick="return gotoBracketsExtra();">' + doMathSrc("▶").outerHTML + '</span>');
    leftMenu.append('<span onclick="return gotoQWETY();">QK</span>');

}

function gotoBracketsExtra() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [
       '<div class="keyboard" data-attr="SCIENTIFIC_MAIN">',
       '<div class="KeyboardRow">',
       '<span class="KeyboardKey" data-attr="59">' + doMathSrc("\\{\\table x;y;").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="60">' + doMathSrc("\\{\\table x;y;z;").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="61">' + doMathSrc("\\table x;y;").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="62">' + doMathSrc("(\\table x;y;)").outerHTML + '</span>',
       '<div class="KeyboardRow">',
       '<span class="KeyboardKey" data-attr="63">' + doMathSrc("(\\table m; ;k;)").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="64">' + doMathSrc("f(x)=\\{\\table -x,x&lt;0;x,x⋝0;\\}").outerHTML + '</span>',
       '</div>',
       '</div>',
       '</div>'
    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
    leftMenu.empty();
    leftMenu.append('<span>' + doMathSrc("[{()}]").outerHTML + '</span>');
    leftMenu.append('<span onclick="return defaultScientific_KeyBoard();">SK</span>');
    leftMenu.append('<span onclick="return gotoBrackets();">' + doMathSrc("◀").outerHTML + '</span>');
    leftMenu.append('<span onclick="return gotoQWETY();">QK</span>');
    rightMenu.empty();
}

function gotoSummation() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [
       '<div class="keyboard" data-attr="SCIENTIFIC_MAIN">',
       '<div class="KeyboardRow">',
       '<span class="KeyboardKey" data-attr="65">' + doMathSrc("∑x").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="66">' + doMathSrc("∑↙{n}↖n").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="67">' + doMathSrc("∑↙{n}↖n{x}").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="68">' + doMathSrc("∑↙{n}{x}").outerHTML + '</span>',
       '<div class="KeyboardRow">',
       '<span class="KeyboardKey" data-attr="69">' + doMathSrc("∑↙{k}(\\table n;k)").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="70">' + doMathSrc("∑↙{i=0}↖n{x}").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="71">' + doMathSrc("∑↙{0⋜i⋜m}↙{0⋜j⋜m}↖n{P(i,j)}").outerHTML + '</span>',
       '</div>',
       '</div>',
       '</div>'
    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
    leftMenu.empty();
    leftMenu.append('<span>' + doMathSrc("∑↙{i=0}↖n").outerHTML + '</span>');
    leftMenu.append('<span onclick="return defaultScientific_KeyBoard();">SK</span>');
    leftMenu.append('<span onclick="return gotoQWETY();">QK</span>');
}

function gotoForAllSym() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [
       '<div class="keyboard" data-attr="SCIENTIFIC_MAIN">',
       '<div class="KeyboardRow">',
       '<span class="KeyboardKey" data-attr="72">' + doMathSrc("⋁x").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="73">' + doMathSrc("⋁↙{-x}↖{x}{y}").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="74">' + doMathSrc("⋁↖{x}{y}").outerHTML + '</span>',
       '<div class="KeyboardRow">',
       '<span class="KeyboardKey" data-attr="75">' + doMathSrc("⋀x").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="76">' + doMathSrc("⋀↙{-x}↖{x}{y}").outerHTML + '</span>',
       '<span class="KeyboardKey" data-attr="77">' + doMathSrc("⋀↖{x}{y}").outerHTML + '</span>',
       '</div>',
       '</div>',
       '</div>'
    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
    leftMenu.empty();
    leftMenu.append('<span>' + doMathSrc("⋁").outerHTML + '</span>');
    leftMenu.append('<span onclick="return defaultScientific_KeyBoard();">SK</span>');
    leftMenu.append('<span onclick="return gotoQWETY();">QK</span>');
}

function gotoQWETY() {
    alert('in progress');
}

function doMathSrc(formula) {
    var srcE = formula,
        ms = srcE.replace(/&([-#.\w]+);|\\([a-z]+)(?: |(?=[^a-z]))/ig,
                function (s, e, m) {
                    if (m && (M.macros_[m] || M.macro1s_[m])) return s;	// e.g. \it or \sc
                    var t = '&' + (e || m) + ';', res = $('<span>' + t + '</span>').text();
                    return res != t ? res : ents_[e || m] || s;
                }),
        h = ms.replace(/</g, '&lt;');
    if (srcE != h) srcE = h;	// assignment may clear insertion point

    var t;
    try {
        t = M.sToMathE(ms, true);
    } catch (exc) {
        t = String(exc);
    }
    return (t);
}


function defaultScientific_KeyBoard() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');



    var keys = [
    '<div class="keyboard" data-attr="SCIENTIFIC_MAIN">',
    '<div class="KeyboardRow">',
    '<span class="KeyboardKey" data-attr="1">' + doMathSrc("x/y").outerHTML + '</span>',
    '<span class="KeyboardKey" data-attr="2">' + doMathSrc("x^y_z").outerHTML + '</span>',
    '<span class="KeyboardKey" data-attr="3">' + doMathSrc("√^n{a^p+b^q}").outerHTML + '</span>',
    '<span class="KeyboardKey" data-attr="4">' + doMathSrc("{dy}/{dx}").outerHTML + '</span>',
    '<span class="KeyboardKey" data-attr="5">' + doMathSrc("∫").outerHTML + '</span>',
    '<span class="KeyboardKey" data-attr="6">[{()}]</span>',
    '<span class="KeyboardKey" data-attr="7">' + doMathSrc("\\table\\sinθ;\\sin^-1θ;\\sin^-1hθ;").outerHTML + '</span>',
    '</div>',
    '<div class="KeyboardRow">',
    '<span class="KeyboardKey" data-attr="8">' + doMathSrc("[\\table \\1, \\0; \\0, \\1]").outerHTML + '</span>',
    '<span class="KeyboardKey" data-attr="9">' + doMathSrc("\\table \\lim↙{h→∞};  \\log_10 1").outerHTML + '</span>',
    '<span class="KeyboardKey" data-attr="10">' + doMathSrc("\\table \\*, \\=; \\-, \\=; \\+, \\=;\\%, \\=;").outerHTML + '</span>',
    '<span class="KeyboardKey" data-attr="11">' + doMathSrc("∑").outerHTML + '</span>',
    '<span class="KeyboardKey" data-attr="12">' + doMathSrc("⋀").outerHTML + '</span>',
    '<span class="KeyboardKey" data-attr="13">' + doMathSrc("⋂").outerHTML + '</span>',
    '<span class="KeyboardKey" data-attr="14">' + doMathSrc("⋃").outerHTML + '</span>',
    '<span class="KeyboardKey" data-attr="15">emojis</span>',
    '</div>',
    '</div>'
    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
    leftMenu.empty();
    leftMenu.append('<span onclick="return gotoQWETY();">QK</span>');







}


var ents_ = { nwarr: '\u2196', swarr: '\u2199' };


function checkUnicodeTitle(event) /* if the event's target is a 1 or 2 character string, then
		its unicode code point(s) are made visible */ {
    var e = event.target, t = e.firstChild;
    if (e.nodeType == 1 /* Element */ && t && e.lastChild == t && t.nodeType == 3 /* Text */) {
        var s = t.data, len = s.length;
        if (0 < len && len <= 2) {
            var iToU = function (i) {
                var h = s.charCodeAt(i).toString(16).toUpperCase();
                while (h.length < 4) h = '0' + h;
                return 'U+' + h;
            }, u = F.fToA(iToU, len).join(' ');
            if (!e.title) e.title = u;
            else if (e.title.indexOf(u) == -1) e.title = u + ': ' + e.title;
        }
    }
}
function insertToSrc2(event) /* if the event's target is a 1 or 2 character string, then
		it is inserted into $('#mathSrc2') */ {
    var e = event.target, t = e.firstChild;
    if (e.nodeType == 1 /* Element */ && t && e.lastChild == t && t.nodeType == 3 /* Text */) {
        var s = t.data, len = s.length;
        if (0 < len && len <= 2) {
            if (s == '\u2044' /* fraction slash */) {
                alert('This buggy "fraction slash" is being replaced by a regular / (U+002F).');
                s = '/';
            } else if (s == '&') s = '&amp;';
            else if (s == '<') s = '&lt;';
            else if ($(e).hasClass('no-meta') || $(e).is('.use-backslash *')) s = '\\' + s;
            else if ($(e).is('.use-sc *')) s = '\\sc ' + s;
            else if ($(e).is('.use-fr *')) s = '\\fr ' + s;

            var te = $('#mathSrc2')[0];
            te.value += s;
            te.focus();
            var n = te.value.length;
            if (te.setSelectionRange) te.setSelectionRange(n, n);
            else if (te.createTextRange) {
                var range = te.createTextRange();
                range.collapse(false);
                range.select();
            }

            doMathSrc1(2);
        }
    }
}


function doMathSrc1(value) {
    var srcE = value;//$('#mathSrc' + n)[0],
    ms = srcE.replace(/&([-#.\w]+);|\\([a-z]+)(?: |(?=[^a-z]))/ig,
            function (s, e, m) {
                if (m && (M.macros_[m] || M.macro1s_[m])) return s;	// e.g. \it or \sc
                var t = '&' + (e || m) + ';', res = $('<span>' + t + '</span>').text();
                return res != t ? res : ents_[e || m] || s;
            }),
    h = ms.replace(/</g, '&lt;');
    if (srcE.value != h) srcE.value = h;	// assignment may clear insertion point

    var t;
    try {
        t = M.sToMathE(ms, true);
    } catch (exc) {
        t = String(exc);
    }
    // $('#mathTgt' + n).empty().append(t);
    $('#editor').append(t);
    
}



$(function () {
    M.trustHtml = true;
    $('#mathSrc1').keyup(F(doMathSrc1, 1)).mouseup(F(doMathSrc1, 1));
    //$('#mathSrc2').keyup(F(doMathSrc1, 2)).mouseup(F(doMathSrc1, 2));
    $('table.prec-form-char td:last-child')
		.addClass('fm-mo')
		.mouseover(checkUnicodeTitle)
		.click(insertToSrc2);


});

function AddTextBox(value) {
    M.trustHtml = true;
    doMathSrc1(value);
    // $('#mathSrc1').keyup(F(doMathSrc1, 1)).mouseup(F(doMathSrc1, 1));
    //$('#mathSrc2').keyup(F(doMathSrc1, 2)).mouseup(F(doMathSrc1, 2));
    //$('table.prec-form-char td:last-child')
    $('span.KeyboardKey')
		.addClass('fm-mo')
		.mouseover(checkUnicodeTitle)
		.click(insertToSrc2);


}