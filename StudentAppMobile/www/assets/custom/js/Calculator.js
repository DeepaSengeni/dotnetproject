var position = 0;
var preserveCount = 0;

var Calculator = function () {
    M.trustHtml = true;
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');
    var txtbox = $('#mathSrc1')[0];
    var powerTextbox = $('#powerTextbox')[0];
    var dytxtbox = $('#dy')[0];
    var dxtxtbox = $('#dx')[0];
    var dy1txtbox = $('#dy1')[0];
    var dx1txtbox = $('#dx1')[0];
    var dy2txtbox = $('#dy2')[0];
    var dx2txtbox = $('#dx2')[0];
    var dy3txtbox = $('#dy3')[0];
    var dx3txtbox = $('#dx3')[0];

    return {

        init: function () {
            editor.attr('contenteditable', 'true');
        },
        initKeyboard: function () {
            defaultScientific_KeyBoard();

        },
        attachEvent: function () {


            $(function () {
                $("body").on('keyup', '#editor', function (e) {
                    $(this).find('.textbox').each(function () {
                        if ($(this).html() != "" && $(this).html() != "<br>") {
                            $(this).addClass('text');
                            //$(this).css('width', ($(this).val().length * 9) + 'px');

                        }
                        else {
                            $(this).removeClass('text');
                            //$(this).css('width', '20px');
                        }
                    });

                });


            });
            $(document).on('click', 'div.textbox', function (e) {
                $('div').removeClass('add');

                $(e.target).addClass('add');


            });

            $(document).on('click', 'span.KeyboardKey', function () {

                var index = parseInt($(this).attr('data-attr'));
                var text = $(this).attr('data-text');
                var src = $(this).attr('data-src');
                console.log($(document.getSelection().anchorNode).attr('class'));
                if ($(document.getSelection().anchorNode).attr('class') == undefined || ($(document.getSelection().anchorNode).attr('class') != 'control' && $(document.getSelection().anchorNode).attr('class') != 'textbox')) {
                 //  $('#editor').focus();
                }
                if (index != 80 && index != 161) {
                    $('#commonKeys').show();
                }
              txtbox = $('#mathSrc1')[0];
              powerTextbox = $('#powerTextbox')[0];
              dytxtbox = $('#dy')[0];
              dxtxtbox = $('#dx')[0];
              dy1txtbox = $('#dy1')[0];
              dx1txtbox = $('#dx1')[0];
              dy2txtbox = $('#dy2')[0];
              dx2txtbox = $('#dx2')[0];
              dy3txtbox = $('#dy3')[0];
              dx3txtbox = $('#dx3')[0];
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
                    case 7:
                        gotoSin();
                        break;
                    case 8:
                        gotoMatrix();
                        break;
                    case 9:
                        gotoLimit();
                        break;
                    case 10:
                        gotoOperator();
                        break;
                    case 11:
                        gotoSummation();
                        break;
                    case 12:
                        gotoForAllSym();
                        break;
                    case 114:
                        gotoForUSym();
                        break;
                    case 115:
                        gotoFortiltUSym();
                        break;
                    case 15:
                        gotoEmoji();
                        break;
                    case 124:
                        gotoAccent();
                        break;
                    case 125:
                        gotoOperatorStructure();
                        break;
                    case 16:
                        // editor.append(doMathSrc("x/y"));                    
                    var trust = txtbox.value + ' / ' + txtbox.value;
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
                        var trust = txtbox.value + '^2';
                        AddTextBox(trust);

                        //editor.append(doMathSrc("x^2"));
                        break;
                    case 22:
                        var trust = txtbox.value + '_' + 'y' + '^' + 2;
                        AddTextBox(trust);
                        // editor.append(doMathSrc("x_y^2"));
                        break;
                    case 23:
                        pasteHtmlAtCaret(doMathSrc("e^{-tiθ}"));
                        //editor.append(doMathSrc("e^{-tiθ}"));
                        //addSpanToMath();
                        break;
                    case 24:
                        var trust = '√{' + txtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("√{a}"));
                        break;
                    case 25:
                        var trust = '√^' + powerTextbox.value + '{' + txtbox.value + '}';
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
                        var trust = '{' + dytxtbox.value + '}/{' + dxtxtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("{dy}/{dx}"));
                        break;
                    case 31:
                        var trust = '{' + dy1txtbox.value + '}/{' + dx1txtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("{△y}/{△x}"));
                        break;
                    case 32:
                        var trust = '{' + dy2txtbox.value + '}/{' + dx2txtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("{∂y}/{∂x}"));
                        break;
                    case 33:
                        var trust = '{' + dy3txtbox.value + '}/{' + dx3txtbox.value + '}';
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
                        var trust = '∰' + txtbox.value + '';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("∰x"));
                        break;
                    case 49:
                        var trust = '∰↙{-' + powerTextbox.value + '}↖{' + powerTextbox.value + '}' + txtbox.value + '';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("∰↙{-x}↖{x}x"));
                        break;
                    case 50:
                        var trust = '∰↙{-' + powerTextbox.value + '}↖{' + powerTextbox.value + '}' + txtbox.value + '';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("∰↙{-x}↖{x}x"));
                        break;
                    case 51:
                        var trust = '(' + txtbox.value + ')';
                        AddTextBox(trust);
                        //editor.append("()");
                        break;
                    case 52:
                        appendEquationFor52();
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
                        appendEquationFor56();
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
                        // setCaret();
                        pasteHtmlAtCaret(doMathSrc("\\{\\table " + txtbox.value + ";" + txtbox.value + ";"));
                        //editor.append(doMathSrc("\\{\\table x;y;"));
                        //addSpanToMath();
                        break;
                    case 60:
                        pasteHtmlAtCaret(doMathSrc("\\{\\table " + txtbox.value + ";" + txtbox.value + ";" + txtbox.value + ";"));
                        //editor.append(doMathSrc("\\{\\table x;y;z;"));
                        //addSpanToMath();
                        break;
                    case 61:
                        pasteHtmlAtCaret(doMathSrc("\\table " + txtbox.value + ";" + txtbox.value + ";"));
                        //editor.append(doMathSrc("\\table x;y;"));
                        //addSpanToMath();
                        break;
                    case 62:
                        pasteHtmlAtCaret(doMathSrc("(\\table " + txtbox.value + ";" + txtbox.value + ";)"));
                        //editor.append(doMathSrc("(\\table x;y;)"));
                        //addSpanToMath();
                        break;
                    case 63:
                        pasteHtmlAtCaret(doMathSrc("(\\table m; ;k;)"));
                        //editor.append(doMathSrc("(\\table m; ;k;)"));
                        //addSpanToMath();
                        break;
                    case 64:
                        pasteHtmlAtCaret(doMathSrc("f(x)=\\{\\table -x,x&lt;0;x,x⋝0;\\}"));
                        //editor.append(doMathSrc("f(x)=\\{\\table -x,x&lt;0;x,x⋝0;\\}"));
                        //addSpanToMath();
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
                        var trust = '∑↙{\\table ' + powerTextbox.value + ';' + powerTextbox.value + '}↖' + powerTextbox.value + '{' + txtbox.value + '}';
                        AddTextBox(trust);
                        // editor.append(doMathSrc("∑↙{i=0}↖n{x}"));
                        break;
                    case 71:
                        var trust = '∑↙{i=0}↖' + powerTextbox.value + '{' + txtbox.value + '}';
                        AddTextBox(trust);

                        // editor.append(doMathSrc("∑↙{0⋜i⋜m}↙{0⋜j⋜m}↖n{P(i,j)}"));
                        break;
                    case 72:
                        var trust = text + txtbox.value + '';
                        AddTextBox(trust);
                        // editor.append(doMathSrc("⋁x"));
                        break;
                    case 73:
                        var trust = text + '↙{-' + powerTextbox.value + '}↖{' + powerTextbox.value + '}{' + txtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("⋁↙{-x}↖{x}{y}"));
                        break;
                    case 74:
                        var trust = text + '↙{' + powerTextbox.value + '}{' + txtbox.value + '}';
                        AddTextBox(trust);
                        // editor.append(doMathSrc("⋁↖{x}{y}"));
                        break;
                    case 75:
                        var trust = text + txtbox.value + '';
                        AddTextBox(trust);
                        // editor.append(doMathSrc("⋀x"));
                        break;
                    case 76:
                        var trust = text + '↙{-' + powerTextbox.value + '}↖{' + powerTextbox.value + '}{' + txtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("⋀↙{-x}↖{x}{y}"));
                        break;
                    case 77:
                        var trust = text + '↙{' + powerTextbox.value + '}{' + txtbox.value + '}';
                        AddTextBox(trust);
                        //editor.append(doMathSrc("⋀↖{x}{y}"));
                        break;
                    case 78:

                        addSymbolToEditor("/");
                        //editor.append(doMathSrc("⋀↖{x}{y}"));
                        break;
                    case 79:

                        addSymbolToEditor("\\");

                        //editor.append(doMathSrc("⋀↖{x}{y}"));
                        break;
                    case 80:

                        //addSymbolToEditor("\\");
                        pasteHtmlAtCaret(text);

                        break;
                    case 81:
                        gotoBracketsExtra();
                        break;
                    case 82:
                        $(function () {
                            var e = $.Event('keypress');
                            e.which = 8; // Character 'A'
                            $("#editor").trigger(e);
                        });

                        break;
                    case 83:
                        pasteHtmlAtCaret(doMathSrc(text + txtbox.value));
                        break;
                    case 84:
                        pasteHtmlAtCaret(doMathSrc(text + "^{-1}" + txtbox.value));
                        break;
                    case 86:
                        var trust = '{log}↙{' + powerTextbox.value + '}{' + txtbox.value + '}';
                        AddTextBox(trust);
                        break;
                    case 87:
                        var trust = '{lim}↙{' + powerTextbox.value + '}{' + txtbox.value + '}';
                        AddTextBox(trust);
                        break;
                    case 88:
                        var trust = '{min}↙{' + powerTextbox.value + '}{' + txtbox.value + '}';
                        AddTextBox(trust);
                        break;
                    case 89:
                        gotoInverseSin();
                        break;
                    case 90:
                        gotoSin();
                        break;
                    case 91:
                        var trust = '{max}↙{' + powerTextbox.value + '}{' + txtbox.value + '}';
                        AddTextBox(trust);
                        break;
                    case 92:
                        var trust = '{ln}↙{' + powerTextbox.value + '}{' + txtbox.value + '}';
                        AddTextBox(trust);

                        break;
                    case 97:
                        gotoHyperbolicSin();
                        break;

                    case 98:
                        gotoInverseSin();
                        break;
                    case 105:

                        gotoHyperbolicInverseSin();
                        break;
                    case 106:

                        gotoHyperbolicSin();
                        break;
                    case 107:

                        appendEquationFor107("<img src='" + src + "' />");
                        break;
                    case 108:
                        pasteHtmlAtCaret(doMathSrc("{[ \\table \\bo " + txtbox.value + ",\\bo " + txtbox.value + ",\\bo " + txtbox.value + "; \\bo " + txtbox.value + ",\\bo " + txtbox.value + ",\\bo " + txtbox.value + "; \\bo " + txtbox.value + ",\\bo " + txtbox.value + ",\\bo " + txtbox.value + "]}"));
                        break;
                    case 109:
                        pasteHtmlAtCaret(doMathSrc("{[ \\table \\bo " + txtbox.value + ",\\bo " + txtbox.value + ",\\bo " + txtbox.value + "; \\bo " + txtbox.value + ",\\bo " + txtbox.value + ",\\bo " + txtbox.value + "; ]}"));
                        break;
                    case 110:
                        pasteHtmlAtCaret(doMathSrc("{[ \\table \\bo " + txtbox.value + ",\\bo " + txtbox.value + ",\\bo " + txtbox.value + "; ]}"));
                        break;
                    case 111:
                        pasteHtmlAtCaret(doMathSrc("{[ \\table \\bo " + txtbox.value + ",\\bo " + txtbox.value + " ]}"));
                        break;
                    case 112:
                        pasteHtmlAtCaret(doMathSrc("{[ \\table \\bo " + txtbox.value + ",\\bo " + txtbox.value + "; \\bo " + txtbox.value + ",\\bo " + txtbox.value + "]}"));
                        break;
                    case 113:
                        pasteHtmlAtCaret(doMathSrc("{[ \\table \\bo " + txtbox.value + ",\\bo " + txtbox.value + "; \\bo " + txtbox.value + ",\\bo " + txtbox.value + "; \\bo " + txtbox.value + ",\\bo " + txtbox.value + "; ]}"));
                        break;
                    case 114:
                        pasteHtmlAtCaret(doMathSrc("{[ \\table \\bo " + txtbox.value + "; \\bo " + txtbox.value + "; \\bo " + txtbox.value + "; ]}"));
                        break;
                    case 115:
                        pasteHtmlAtCaret(doMathSrc("{[ \\table \\bo " + txtbox.value + "; \\bo " + txtbox.value + " ]}"));
                        break;
                    case 118:
                        pasteHtmlAtCaret(doMathSrc("{[ \\table \\bo 1,\\bo 0,\\bo 0; \\bo 0,\\bo 1,\\bo 0;\\bo 0,\\bo 0,\\bo 1; ]}"));
                        break;
                    case 119:
                        pasteHtmlAtCaret(doMathSrc("{[ \\table \\bo 1,\\bo ,\\bo ; \\bo ,\\bo 1,\\bo ;\\bo ,\\bo ,\\bo 1; ]}"));
                        break;
                    case 120:
                        pasteHtmlAtCaret(doMathSrc("{[ \\table \\bo 1,\\bo 0; \\bo 0,\\bo 1; ]}"));
                        break;
                    case 121:
                        pasteHtmlAtCaret(doMathSrc("{[ \\table \\bo 1,\\bo ; \\bo ,\\bo 1; ]}"));
                        break;
                    case 122:
                        pasteHtmlAtCaret(doMathSrc("{( \\table \\bo " + txtbox.value + ",\\bo " + txtbox.value + "; \\bo " + txtbox.value + ",\\bo " + txtbox.value + ")}"));
                        break;
                    case 123:
                        pasteHtmlAtCaret(doMathSrc("{[ \\table \\bo " + txtbox.value + ",\\bo " + txtbox.value + "; \\bo " + txtbox.value + ",\\bo " + txtbox.value + "]}"));
                        break;
                    case 126:
                        var trust = txtbox.value + '↖{⋅}';
                        AddTextBox(trust);
                        break;
                    case 127:
                        var trust = txtbox.value + '↖{⋅⋅}';
                        AddTextBox(trust);
                        break;
                    case 128:
                        var trust = txtbox.value + '↖{⋅⋅⋅}';
                        AddTextBox(trust);
                        break;
                    case 129:
                        var trust = txtbox.value + '↖{ˆ}'; //  ˆ circumflex accent
                        AddTextBox(trust);
                        break;
                    case 130:
                        var trust = txtbox.value + '↖{ˇ}'; // ˇ caron
                        AddTextBox(trust);
                        break;
                    case 131:
                        var trust = txtbox.value + '↖{ˊ}'; // ˊ accute accent
                        AddTextBox(trust);
                        break;
                    case 132:
                        var trust = txtbox.value + '↖{ˋ}'; // ˋ grave accent
                        AddTextBox(trust);
                        break;
                    case 133:
                        var trust = txtbox.value + '↖{&OverParenthesis;}'; // ͝  breve accent 
                        AddTextBox(trust);
                        break;
                    case 134:
                        var trust = txtbox.value + '↖{~}'; // ͝  tild
                        AddTextBox(trust);
                        break;
                    case 135:
                        var trust = txtbox.value + '↖{-}'; // ͝  bar 
                        AddTextBox(trust);
                        break;
                    case 136:
                        var trust = txtbox.value + '↖{═}'; // ͝  double overbar 
                        AddTextBox(trust);
                        break;
                    case 137:
                        var trust = txtbox.value + '↖{&OverBrace;}';   // &OverBrace;
                        AddTextBox(trust);
                        break;
                    case 138:
                        var trust = txtbox.value + '↙{&UnderBrace;}';   // &OverBrace;
                        AddTextBox(trust);
                        break;
                    case 139:
                        var trust = txtbox.value + '↖{&OverBrace;}↖{' + txtbox.value + '}';   // &OverBrace;
                        AddTextBox(trust);
                        break;
                    case 140:
                        var trust = txtbox.value + '↖{&UnderBrace;}↖{' + txtbox.value + '}';   // &OverBrace;
                        AddTextBox(trust);
                        break;
                    case 141:
                        var trust = txtbox.value + '↖{&larr;}';  //  ←
                        AddTextBox(trust);
                        break;
                    case 142:
                        var trust = txtbox.value + '↖{&rarr;}';  //  →
                        AddTextBox(trust);
                        break;
                    case 143:
                        var trust = txtbox.value + '↖{↔}';  //  ↔
                        AddTextBox(trust);
                        break;
                    case 144:
                        var trust = txtbox.value + '↖{↼}';  //  ↼
                        AddTextBox(trust);
                        break;
                    case 145:
                        var trust = txtbox.value + '↖{⇀}';  //  ⇀	
                        AddTextBox(trust);
                        break;
                    case 146:
                        var trust = txtbox.value + '↙{&larr;}';  //  ←
                        AddTextBox(trust);
                        break;
                    case 147:
                        var trust = txtbox.value + '↙{&rarr;}';  //  →
                        AddTextBox(trust);
                        break;
                    case 148:
                        var trust = txtbox.value + '↖{&lArr;}';  //  ←
                        AddTextBox(trust);
                        break;
                    case 149:
                        var trust = txtbox.value + '↖{&rArr;}';  //  →
                        AddTextBox(trust);
                        break;
                    case 150:
                        var trust = txtbox.value + '↙{&lArr;}';  //  ←
                        AddTextBox(trust);
                        break;
                    case 151:
                        var trust = txtbox.value + '↙{&rArr;}';  //  →
                        AddTextBox(trust);
                        break;
                    case 152:
                        var trust = ':=';  //  →
                        AddTextBox(trust);
                        break;
                    case 153:
                        var trust = '==';  //  →
                        AddTextBox(trust);
                        break;
                    case 154:
                        var trust = ' &#8798;';  //  measured by... alt: &#x225E;
                        AddTextBox(trust);
                        break;
                    case 155:
                        var trust = ' &#8797;';  // DELTA EQUAL TO... alt: &#x225D;
                        AddTextBox(trust);
                        break;
                    case 156:
                        var trust = '&#8796;';  // EQUAL TO BY DEFINITION.... alt: &#x225C;
                        AddTextBox(trust);
                        break;
                    case 157:
                        var trust = txtbox.value + '↙{―}';  //  →
                        AddTextBox(trust);
                        break;
                    case 158:
                        var trust = txtbox.value + '↖{―}';  //  ←
                        AddTextBox(trust);
                        break;
                    case 159:
                        var html = '<div class="span" style="border: 1.5pt solid #00003a; vertical-align: 0.22em;"> <div class="textbox"></div></div>&nbsp;&nbsp;';
                        appendTextAtCaret(html);
                        break;
                    case 160:
                        var html = '<div class="span" style="border: 1.5pt solid #00003a;"><mrow><mo class="fm-infix"><mtext><mtext>a</mtext><span class="fm-script fm-inline" style="vertical-align: 0.7em;"><mtext>2&nbsp;</mtext></span>= b</mtext><span class="fm-script fm-inline" style="vertical-align: 0.7em;"><mtext>2</mtext></span>+c</mo><msup><span class="fm-script fm-inline" style="vertical-align: 0.7em;"><mtext>2</mtext></span></msup></mrow></div>&nbsp;&nbsp;'
                        appendTextAtCaret(html);
                        break;
                    case 161:
                        pasteHtmlAtCaret(text);
                        if (preserveCount < 2) {
                            gotoQWETY();
                        }
                        break;

                }
            });
            $('#editor').on('click', function (e) {
                $('.add').removeClass('add');
            });

            $('#submitQuestion').click(function () {
                $('#editor').find('input').each(function () {

                    var value = $(this).val();
                    $(this).attr('value', value);
                    // $(this).remove();                  

                });

            });
        }
    };


}();
var ents_ = { nwarr: '\u2196', swarr: '\u2199' };

function gotoSpecialSymbols() {
    $('#commonKeys').show();
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');


    var keys = [
         '<div class="col-md-12"><div style="text-align:center" class="spcl">',

           '<br>',
            '<span class="KeyboardKey" data-attr="80" data-text="!"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s1.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="80" data-text="@"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s2.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="80" data-text="#"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s3.png" /></a></span>',
     '<span class="KeyboardKey" data-attr="80" data-text="$"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="80" data-text="/"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s5.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="80" data-text="^"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s6.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="&"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s7.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="*"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s8.png" /></a></span>',
          '<span class="KeyboardKey" data-attr="80" data-text="="> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s9.png" /></a></span>',

           '</div></div>',

        '<span class="KeyboardKey" data-attr="93" onclick="gotoSpecialSymbols1()"> <a href="javascript:;" class="button imgpos2"><img src="assets/custom/KeyboardIcons/images/special character/next.png" /></a></span>',
       ,
    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
}

function gotoSpecialSymbols1() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');


    var keys = [

    '<span class="KeyboardKey" onclick="gotoSpecialSymbols()"> <a href="javascript:;" class="button imgpos"><img src="assets/custom/KeyboardIcons/images/special character/previous.png" /></a></span></div>',
         '<div class="col-md-12"><div style="text-align:center" class="spcl">',
      '<span class="KeyboardKey" data-attr="80" data-text="("> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s11.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="80" data-text=")"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s12.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="80" data-text="&#39;"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s13.png" /></a></span>',
     '<span class="KeyboardKey" data-attr="80" data-text="&#34;"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/doublequotes.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="80" data-text=":"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s14.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="80" data-text=";"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s15.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text=","> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s16.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="-"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s17.png" /></a></span>',
          '<span class="KeyboardKey" data-attr="80" data-text="+"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s18.png" /></a></span>',
          '<span class="KeyboardKey" data-attr="80" data-text="÷"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s19.png" /></a></span>',

           '<br>',
           '<span class="KeyboardKey" data-attr="80" data-text="≠"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s20.png" /></a></span>',
            '<span class="KeyboardKey" data-attr="80" data-text="<"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s21.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="80" data-text=">"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s22.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="80" data-text="<<"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s23.png" /></a></span>',
     '<span class="KeyboardKey" data-attr="80" data-text=">>"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s24.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="80" data-text="≤"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s25.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="80" data-text="≥"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s26.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="±"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s27.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="∓"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s28.png" /></a></span>',


           '</div></div>',

        '<span class="KeyboardKey" onclick="gotoSpecialSymbols2()" > <a href="javascript:;" class="button imgpos2"><img src="assets/custom/KeyboardIcons/images/special character/next.png" /></a></span>',

    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
}

function gotoSpecialSymbols2() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');


    var keys = [

        '<span class="KeyboardKey" onclick="gotoSpecialSymbols1()"> <a href="javascript:;" class="button imgpos"><img src="assets/custom/KeyboardIcons/images/special character/previous.png" /></a></span></div>',
         '<div class="col-md-12"><div style="text-align:center" class="spcl">',
      '<span class="KeyboardKey" data-attr="80" data-text="∞"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s30.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="80" data-text="~"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s31.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="80" data-text="x"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s32.png" /></a></span>',
     '<span class="KeyboardKey" data-attr="80" data-text="ˠ"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s33.png" /></a></span>',

       '<span class="KeyboardKey" data-attr="80" data-text="≈"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s35.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="≈"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s36.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="≡"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s37.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="Ɐ"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s38.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="ʗ"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s39.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="ə"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s40.png" /></a></span>',

           '<br>',
            '<span class="KeyboardKey" data-attr="80" data-text="√"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s41.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="80" data-text="∑"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s42.png" /></a></span>',
     '<span class="KeyboardKey" data-attr="80" data-text="V"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s43.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="80" data-text="U"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s44.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="80" data-text="∩"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s45.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="Ø"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s46.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="%"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s47.png" /></a></span>',
'<span class="KeyboardKey" data-attr="80" data-text="€"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s48.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="£"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s49.png" /></a></span>',

           '</div></div>',

        '<span class="KeyboardKey" onclick="gotoSpecialSymbols3()" > <a href="javascript:;" class="button imgpos2"><img src="assets/custom/KeyboardIcons/images/special character/next.png" /></a></span>',

    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
}

function gotoSpecialSymbols3() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');


    var keys = [

        '<span class="KeyboardKey" onclick="gotoSpecialSymbols2()"> <a href="javascript:;" class="button imgpos"><img src="assets/custom/KeyboardIcons/images/special character/previous.png" /></a></span></div>',
         '<div class="col-md-12"><div style="text-align:center" class="spcl">',
      '<span class="KeyboardKey" data-attr="80" data-text="°"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s50.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="80" data-text="°C"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s51.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="80" data-text="°F"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s52.png" /></a></span>',
     '<span class="KeyboardKey" data-attr="80" data-text="∆"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s53.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="80" data-text="ς "> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/delta1.png" /></a></span>',

        '<span class="KeyboardKey" data-attr="80" data-text="Ǝ"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s55.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="Ɇ"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s56.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="Ɛ"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s57.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="Ȝ"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s58.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="•"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/s59.png" /></a></span>',


           '<br>',
            '<span class="KeyboardKey" data-attr="80" data-text="∵"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/60.png" /></a></span>',
            '<span class="KeyboardKey" data-attr="80" data-text="^"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/61.png" /></a></span>',
            '<span class="KeyboardKey" data-attr="80" data-text="←"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/63.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="80" data-text="→"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/62.png" /></a></span>',

      '<span class="KeyboardKey" data-attr="80" data-text="↑"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/64.png" /></a></span>',

       '<span class="KeyboardKey" data-attr="80" data-text="↓"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/65.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="↔"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/66.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="∂"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/67.png" /></a></span>',
'<span class="KeyboardKey" data-attr="80" data-text="β"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/68.png" /></a></span>',


           '</div></div>',

        '<span class="KeyboardKey" onclick="gotoSpecialSymbols4()"> <a href="javascript:;" class="button imgpos2"><img src="assets/custom/KeyboardIcons/images/special character/next.png" /></a></span>',

    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
}

function gotoSpecialSymbols4() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');


    var keys = [

        '<span class="KeyboardKey" onclick="gotoSpecialSymbols3()"> <a href="javascript:;" class="button imgpos"><img src="assets/custom/KeyboardIcons/images/special character/previous.png" /></a></span></div>',
         '<div class="col-md-12"><div style="text-align:center" class="spcl">',
      '<span class="KeyboardKey" data-attr="80" data-text="Ɣ"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/69.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="80" data-text="Ɛ"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/70.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="80" data-text="E"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/71.png" /></a></span>',
     '<span class="KeyboardKey" data-attr="80" data-text="Ɵ"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/72.png" /></a></span>',

       '<span class="KeyboardKey" data-attr="80" data-text="V"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/73.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="µ"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/74.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="π"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/75.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="p"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/76.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="σ"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/77.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="Ԏ"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/78.png" /></a></span>',

           '<br>',
            '<span class="KeyboardKey" data-attr="80" data-text="φ"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/79.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="80" data-text="w"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/80.png" /></a></span>',
     '<span class="KeyboardKey" data-attr="80" data-text="⁞"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/81.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="80" data-text="…"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/82.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="80" data-text="⋱"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/83.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="⋱"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/84.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="ﬡ"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/85.png" /></a></span>',
'<span class="KeyboardKey" data-attr="80" data-text="בּ"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/86.png" /></a></span>',


           '</div></div>',

        '<span class="KeyboardKey" onclick="gotoSpecialSymbols5()" > <a href="javascript:;" class="button imgpos2"><img src="assets/custom/KeyboardIcons/images/special character/next.png" /></a></span>',

    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
}

function gotoSpecialSymbols5() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');


    var keys = [

        '<span class="KeyboardKey" onclick="gotoSpecialSymbols4()"> <a href="javascript:;" class="button imgpos"><img src="assets/custom/KeyboardIcons/images/special character/previous.png" /></a></span></div>',
         '<div class="col-md-12"><div style="text-align:center" class="spcl">',
      '<span class="KeyboardKey" data-attr="80" data-text="♥"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/87.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="80" data-text="ꜟ"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/88.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="80" data-text="¿"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/89.png" /></a></span>',
     '<span class="KeyboardKey" data-attr="80" data-text="♀"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/90.png" /></a></span>',

       '<span class="KeyboardKey" data-attr="80" data-text="♣"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/91.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="*"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/92.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="▲"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/93.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="►"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/94.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="▼"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/95.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="◄"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/96.png" /></a></span>',

           '<br>',
            '<span class="KeyboardKey" data-attr="80" data-text="☺"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/97.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="80" data-text="☻"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/98.png" /></a></span>',
     '<span class="KeyboardKey" data-attr="80" data-text="☼"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/99.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="80" data-text="♫"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/100.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="80" data-text="("> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/101.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text=")"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/102.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="Ѽ"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/103.png" /></a></span>',
'<span class="KeyboardKey" data-attr="80" data-text= "&nbsp;҈ &nbsp;"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/104.png" /></a></span>',
'<span class="KeyboardKey" data-attr="80" data-text="۩"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/105.png" /></a></span>',

           '</div></div>',


        '</div>',
    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
}

function gotoXbyy() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [

       '<span class="KeyboardKey" data-attr="16"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/xfunction/xupony2.png" /></a></span>',

       '<span class="KeyboardKey" data-attr="78"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/xfunction/ximg1.png" /></a></span>',
       //'<span class="KeyboardKey" data-attr="79"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/xfunction/ximg1.png" /></a></span>',
       '<span class="KeyboardKey" > <a href="javascript:;" class="button"></a></span>',
       '<span class="KeyboardKey" data-attr="17"><a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/xfunction/ximg2.png" /></a></span>',

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
       '<span class="KeyboardKey" data-attr="18"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/x-power-function/xpwrimg1.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="19"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/x-power-function/xpwrimg2.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="20"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/x-power-function/xpwrimg3.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="21"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/x-power-function/xpwrimg4.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="22"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/x-power-function/xpwrimg5.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="23"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/x-power-function/xpwrimg6.png" /></a></span>',
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
      '<span class="KeyboardKey" data-attr="24"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/squareroot/aimg1.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="25"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/squareroot/aimg2.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="26"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/squareroot/aimg3.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="27"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/squareroot/aimg4.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="28"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/squareroot/aimg5.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="29"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/squareroot/aimg6.png" /></a></span>',
      //'<span class="KeyboardKey" data-attr="30"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/squareroot/aimg7.png" /></a></span>',
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
        '<span class="KeyboardKey" data-attr="30"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/other/dxupondy.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="31"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/other/deltayupondeltax.png" /></a></span>',
          '<span class="KeyboardKey" data-attr="32"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/other/yuponx3.png" /></a></span>',
           '<span class="KeyboardKey" data-attr="33"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/other/yuponx4.png" /></a></span>',

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
        '<span class="KeyboardKey" data-attr="34"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/integration img/intimg1.png" /></a></span>',

        '<span class="KeyboardKey" data-attr="35"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/integration img/inteim2.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="36"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/integration img/intim3.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="37"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/integration img/intim4.png" /></a></span>',
              //'<span class="KeyboardKey" data-attr="38"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/integration img/intimg.png" /></a></span>',
              //'<span class="KeyboardKey" onclick="return gotoIntegrationWithLimitextra();"><a href="javascript:;" class="button">' + doMathSrc("▶").outerHTML + '</a></span>',
               '<span class="KeyboardKey" onclick="gotoIntegrationWithLimitextra()" > <a href="javascript:;" class="button imgpos2"><img src="assets/custom/KeyboardIcons/images/special character/next.png" /></a></span>',
    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
    leftMenu.empty();
    leftMenu.append('<span>' + doMathSrc("∫↙{-x}↖{x}").outerHTML + '</span>');
    leftMenu.append('<span onclick="return defaultScientific_KeyBoard();">SK</span>');
    leftMenu.append('<span onclick="return gotoQWETY();">QK</span>');
    rightMenu.empty();
    rightMenu.append('<span class="KeyboardKey" onclick="return gotoIntegrationWithLimitextra();">' + doMathSrc("▶").outerHTML + '</span>');

}

function gotoIntegrationWithLimitextra() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [
       '<div class="keyboard" data-attr="SCIENTIFIC_MAIN">',
       '<div class="KeyboardRow">',
       '<span class="KeyboardKey" onclick="return gotoIntegrationWithLimit();"> <a href="javascript:;" class="button imgpos"><img src="assets/custom/KeyboardIcons/images/special character/previous.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="39"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/integration img/simpletripleintegration.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="40"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/integration img/trippleintegration.png" /></a></span>',
       //'<span class="KeyboardKey" data-attr="41"> <a href="javascript:;" class="button">' + doMathSrc("∫∫∫↙{-x}↖{x}x").outerHTML + '</a></span>',
       '<div class="KeyboardRow">',
       '<span class="KeyboardKey" data-attr="42"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/integration img/integral1.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="43"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/integration img/integral2.png" /></a></span>',
       //'<span class="KeyboardKey" data-attr="44"> <a href="javascript:;" class="button">' + doMathSrc("∮↙{-x}↖{x}x").outerHTML + '</a></span>',
       //'<span class="KeyboardKey" onclick="return gotoIntegrationWithLimitextraExtra();"> <a href="javascript:;" class="button">' + doMathSrc("▶").outerHTML + '</a></span>',
        '<span class="KeyboardKey" onclick="gotoIntegrationWithLimitextraExtra()" > <a href="javascript:;" class="button imgpos2"><img src="assets/custom/KeyboardIcons/images/special character/next.png" /></a></span>',
       '</div>',
       '</div>',
       '</div>'
    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));


}

function gotoIntegrationWithLimitextraExtra() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [
       '<div class="keyboard" data-attr="SCIENTIFIC_MAIN">',
       '<div class="KeyboardRow">',
        '<span class="KeyboardKey" onclick="return gotoIntegrationWithLimitextra();"><a href="javascript:;" class="button imgpos"><img src="assets/custom/KeyboardIcons/images/special character/previous.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="45"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/integration img/integral3.png" /></a></span>',

       '<span class="KeyboardKey" data-attr="46"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/integration img/integral4.png" /></a></span>',
       //'<span class="KeyboardKey" data-attr="47"><a href="javascript:;" class="button">' + doMathSrc("∯↙{-x}↖{x}x").outerHTML + '</a></span>',
       '<div class="KeyboardRow">',
       '<span class="KeyboardKey" data-attr="48"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/integration img/integral6.png" /></a></span>',

       '<span class="KeyboardKey" data-attr="49"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/integration img/integralim5png" /></a></span>',
       //'<span class="KeyboardKey" data-attr="50"><a href="javascript:;" class="button">' + doMathSrc("∰↙{-x}↖{x}x").outerHTML + '</a></span>',

       '</div>',
       '</div>',
       '</div>'
    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));


}

function gotoMatrix() {

    var keyboard = $('#keyboadArea');
    var editor = $('#editor');


    var keys = [
        '<div class="col-md-12"><div style="text-align:center">',
        '<span class="KeyboardKey" data-attr="108" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/matrix/mimg8.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="109" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/matrix/mimg6.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="110" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/matrix/mimg3.png" /></a></span>',

       '<span class="KeyboardKey" data-attr="111" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/matrix/mimg1.png" /></a></span>',

      '<span class="KeyboardKey" data-attr="112" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/matrix/bracketimg2.png" /></a></span>',
      '<br>',
      '<span class="KeyboardKey" data-attr="113" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/matrix/mimg7.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="114" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/matrix/mimg4.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="115" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/matrix/mimg2.png" /></a></span>',
 //     '<span class="KeyboardKey" data-attr="116" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/matrix/matrixbracketimg1.png" /></a></span>',
 //'<span class="KeyboardKey" data-attr="117" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/matrix/marixbracketimg2.png" /></a></span>',
        '</div>',
        '</div>',

        '<span class="KeyboardKey" onclick="gotoMatrix1()" > <a href="javascript:;" class="button imgpos2"><img src="assets/custom/KeyboardIcons/images/special character/next.png" /></a></span>',


    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));


}

function gotoMatrix1() {

    var keyboard = $('#keyboadArea');
    var editor = $('#editor');


    var keys = [
         '<span class="KeyboardKey" onclick="gotoMatrix()"> <a href="javascript:;" class="button imgpos"><img src="assets/custom/KeyboardIcons/images/special character/previous.png" /></a></span></div>',
        '<div class="col-md-12" style="text-align:center">',
        '<span class="KeyboardKey" data-attr="118"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/matrix/unitmatrix.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="119" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/matrix/unitmatrix4.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="120" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/matrix/unitmatrix2.png" /></a></span>',

       '<span class="KeyboardKey" data-attr="121" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/matrix/unitmatrix3.png" /></a></span>',
       '<br>',
   '<span class="KeyboardKey" data-attr="122" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/matrix/bracketmatrix1.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="123" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/matrix/mimg9.png" /></a></span>',
        '</div>',



    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));


}

function gotoOperator() {

    var keyboard = $('#keyboadArea');
    var editor = $('#editor');


    var keys = [

        '<span class="KeyboardKey" data-attr="80" data-text="+="> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/operators/plusequal.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="80" data-text="-=" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/operators/minusequal.png" /></a></span>',




    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));


}

function gotoLimit() {

    var keyboard = $('#keyboadArea');
    var editor = $('#editor');


    var keys = [

        '<span class="KeyboardKey" data-attr="83" data-text="log"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/log/logim2.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="86" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/log/logim1.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="87" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/log/limim1.png" /></a></span>',
      '<br>',
       '<span class="KeyboardKey" data-attr="88" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/log/minimg1.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="91" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/log/maximg1.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="92" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/log/inimg1.png" /></a></span>',



    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));


}

function gotoAccent() {

    var keyboard = $('#keyboadArea');
    var editor = $('#editor');


    var keys = [
        '<div class="col-md-12 accentContainer"><div style="text-align:center">',
        '<span class="KeyboardKey" data-attr="126" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/accent17.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="127" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/accent18.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="128" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/accent19.png" /></a></span>',

       '<span class="KeyboardKey" data-attr="129" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/accent20.png" /></a></span>',

      '<span class="KeyboardKey" data-attr="130" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/accent1.png" /></a></span>',
      '<br>',
      '<span class="KeyboardKey" data-attr="131" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/accent2.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="132" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/accent3.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="133" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/accent4.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="134" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/accent5.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="135" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/accent6.png" /></a></span>',
 //     '<span class="KeyboardKey" data-attr="116" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/matrix/matrixbracketimg1.png" /></a></span>',
 //'<span class="KeyboardKey" data-attr="117" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/matrix/marixbracketimg2.png" /></a></span>',
        '</div>',
        '</div>',

        '<span class="KeyboardKey" onclick="gotoAccent1()" > <a href="javascript:;" class="button imgpos2"><img src="assets/custom/KeyboardIcons/images/special character/next.png" /></a></span>',


    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));


}

function gotoAccent1() {

    var keyboard = $('#keyboadArea');
    var editor = $('#editor');


    var keys = [
         '<span class="KeyboardKey" onclick="gotoAccent()"> <a href="javascript:;" class="button imgpos"><img src="assets/custom/KeyboardIcons/images/special character/previous.png" /></a></span></div>',
        '<div class="col-md-12 accentContainer" style="text-align:center">',
        '<span class="KeyboardKey" data-attr="136"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/accent7.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="137" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/accent8.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="138" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/accent9.png" /></a></span>',

       '<span class="KeyboardKey" data-attr="139" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/accent10.png" /></a></span>',
       '<br>',
   '<span class="KeyboardKey" data-attr="140" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/accent11.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="141" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/accent12.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="142" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/accent13.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="143" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/accent14.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="144" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/accent15.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="145" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/accent16.png" /></a></span>',
        '</div>',

        '<span class="KeyboardKey" onclick="gotoAccent2()" > <a href="javascript:;" class="button imgpos2"><img src="assets/custom/KeyboardIcons/images/special character/next.png" /></a></span>',



    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));


}
function gotoAccent2() {

    var keyboard = $('#keyboadArea');
    var editor = $('#editor');


    var keys = [
         '<span class="KeyboardKey" onclick="gotoAccent1()"> <a href="javascript:;" class="button imgpos"><img src="assets/custom/KeyboardIcons/images/special character/previous.png" /></a></span></div>',
        '<div class="col-md-12 accentContainer" style="text-align:center">',
        '<span class="KeyboardKey" data-attr="157"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/overbar.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="158" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/underbar.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="159" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/border1.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="160" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/accent/border2.png" /></a></span>',
        '</div>',



    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));


}

function gotoOperatorStructure() {

    var keyboard = $('#keyboadArea');
    var editor = $('#editor');


    var keys = [
        '<div class="col-md-12 operatorContainer"><div style="text-align:center">',
      '<span class="KeyboardKey" data-attr="146" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/operators/operator3.png" /></a></span>',

       '<span class="KeyboardKey" data-attr="147" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/operators/operator4.png" /></a></span>',

      '<span class="KeyboardKey" data-attr="148" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/operators/operator5.png" /></a></span>',
      '<br>',
      '<span class="KeyboardKey" data-attr="149" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/operators/operator6.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="150" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/operators/operator7.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="151" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/operators/operator8.png" /></a></span>',
        '</div>',
        '</div>',

       '<span class="KeyboardKey" onclick="gotoOperatorStructure1()" > <a href="javascript:;" class="button imgpos2"><img src="assets/custom/KeyboardIcons/images/special character/next.png" /></a></span>',


    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));


}

function gotoOperatorStructure1() {

    var keyboard = $('#keyboadArea');
    var editor = $('#editor');


    var keys = [
         '<span class="KeyboardKey" onclick="gotoOperatorStructure()"> <a href="javascript:;" class="button imgpos"><img src="assets/custom/KeyboardIcons/images/special character/previous.png" /></a></span></div>',
        '<div class="col-md-12" style="text-align:center">',
         '<span class="KeyboardKey" data-attr="152" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/operators/oimg1.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="153" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/operators/oimg2.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="154" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/operators/mimg2.png" /></a></span>',
      '<br>',
      '<span class="KeyboardKey" data-attr="155" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/operators/defimg1.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="156" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/operators/deltaimg1.png" /></a></span>',
        '</div>',



    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));


}
function gotoSin() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [
        '<div class="col-md-12"><div style="text-align:center">',
        '<span class="KeyboardKey" data-attr="83" data-text="\\table \\sin"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/sintheta.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="83" data-text="\\table \\cos"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/costheta.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="83" data-text="\\table \\tan"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/tantheta.png" /></a></span>',
      '<br>',
       '<span class="KeyboardKey" data-attr="83" data-text="\\table \\cosec"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/cosectheta.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="83" data-text="\\table \\sec"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/sectheta.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="83" data-text="\\table \\cot"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/cottheta.png" /></a></span>',

        '</div>',
        '</div>',

        '<span class="KeyboardKey" data-attr="89" ><a href="javascript:;" class="button imgpos2"><img src="assets/custom/KeyboardIcons/images/special character/next.png" /></a></span>',


    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));


}

function gotoInverseSin() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [

        '<span class="KeyboardKey" data-attr="90" > <a href="javascript:;" class="button imgpos"><img src="assets/custom/KeyboardIcons/images/special character/previous.png" /></a></span>',
        '<div class="col-md-12"><div style="text-align:center">',
        '<span class="KeyboardKey" data-attr="84" data-text="\\table \\sin"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/sininversethea.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="84" data-text="\\table \\cos"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/cosinversetheta.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="84" data-text="\\table \\tan"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/taninversetheta.png" /></a></span>',
      '<br>',
       '<span class="KeyboardKey" data-attr="84" data-text="\\table \\cosec"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/cosecinversetheta.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="84" data-text="\\table \\sec"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/secinversetheta.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="84" data-text="\\table \\cot"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/cotinversetheta.png" /></a></span>',

        '</div>',
        '</div>',

        '<span class="KeyboardKey" data-attr="97" > <a href="javascript:;" class="button imgpos2"><img src="assets/custom/KeyboardIcons/images/special character/next.png" /></a></span>',


    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));


}

function gotoHyperbolicSin() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [

        '<span class="KeyboardKey" data-attr="98" > <a href="javascript:;" class="button imgpos"><img src="assets/custom/KeyboardIcons/images/special character/previous.png" /></a></span>',
        '<div class="col-md-12"><div style="text-align:center">',
        '<span class="KeyboardKey" data-attr="83" data-text="\\table \\sinh"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/hyperbolicsintheta.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="83" data-text="\\table \\cosh"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/hyperboliccostheta.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="83" data-text="\\table \\tanh"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/hyperbolictanteta.png" /></a></span>',
      '<br>',
       '<span class="KeyboardKey" data-attr="83" data-text="\\table \\cosech"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/hyperboliccosectheta.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="83" data-text="\\table \\sech"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/hyperbolicsectheta.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="83" data-text="\\table \\coth"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/hyperboliccottheta.png" /></a></span>',

        '</div>',
        '</div>',

        '<span class="KeyboardKey" data-attr="105" > <a href="javascript:;" class="button imgpos2"><img src="assets/custom/KeyboardIcons/images/special character/next.png" /></a></span>',


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

function gotoHyperbolicInverseSin() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [

        '<span class="KeyboardKey" data-attr="106" > <a href="javascript:;" class="button imgpos"><img src="assets/custom/KeyboardIcons/images/special character/previous.png" /></a></span>',
        '<div class="col-md-12"><div style="text-align:center">',
        '<span class="KeyboardKey"  data-attr="84" data-text="\\table \\sinh"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/hyperbolicsininverse.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="84" data-text="\\table \\cosh"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/hyperboliccosinverse.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="84" data-text="\\table \\tanh"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/hyperbolictaninverse.png" /></a></span>',
      '<br>',
       '<span class="KeyboardKey" data-attr="84" data-text="\\table \\cosech"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/hyperboliccosecinverse.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="84" data-text="\\table \\sech"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/hyperbolicsecinverse.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="84" data-text="\\table \\coth"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sin/hyperboliccotinverse.png" /></a></span>',

        '</div>',
        '</div>',


    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));


}

function gotoBrackets() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [
        '<div class="col-md-12"><div style="text-align:center">',
        '<span class="KeyboardKey" data-attr="51"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/bracketimages/bracketim1.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="52"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/bracketimages/bracketimg2.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="53"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/bracketimages/bracketimg3.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="54"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/bracketimages/backetleftright.png" /></a></span>',
        '<br>',
        '<span class="KeyboardKey" data-attr="55"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/bracketimages/bracketimg4.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="56"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/bracketimages/bracketimg5.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="57"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/bracketimages/bracketim6.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="58"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/bracketimages/bracketim7.png" /></a></span>',
        '</div>',
        '</div>',

        '<span class="KeyboardKey" data-attr="81" > <a href="javascript:;" class="button imgpos2"><img src="assets/custom/KeyboardIcons/images/special character/next.png" /></a></span>',


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
    //position = getCaretPosition(document.getElementById("editor"));

    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [
         '<div class="col-md-12"><div style="text-align:center">',
      '<span class="KeyboardKey" onclick="return gotoBrackets();"> <a href="javascript:;" class="button imgpos"><img src="assets/custom/KeyboardIcons/images/special character/previous.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="59"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/bracketimages/o1.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="60"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/bracketimages/o2.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="61"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/bracketimages/o3.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="62"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/bracketimages/o4.png" /></a></span>',
       '<br>',
       '<span class="KeyboardKey" data-attr="63"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/bracketimages/05.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="64"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/bracketimages/07.png" /></a></span>',
       '</div>',
       '</div>',

    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));

}

function gotoSummation() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [
        '<span class="KeyboardKey" data-attr="65"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sigmaimages/sigmaimg1.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="66"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sigmaimages/sigmaimg2.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="67"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sigmaimages/sigmaimg3.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="68"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sigmaimages/sigmaimg4.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="69"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sigmaimages/sigmaimage.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="70"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sigmaimages/sigmaimg6.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="71"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/sigmaimages/sigmaimg7.png" /></a></span>',

       //'<div class="keyboard" data-attr="SCIENTIFIC_MAIN">',
       //'<div class="KeyboardRow">',
       //'<span class="KeyboardKey" data-attr="65">' + doMathSrc("∑x").outerHTML + '</span>',
       //'<span class="KeyboardKey" data-attr="66">' + doMathSrc("∑↙{n}↖n").outerHTML + '</span>',
       //'<span class="KeyboardKey" data-attr="67">' + doMathSrc("∑↙{n}↖n{x}").outerHTML + '</span>',
       //'<span class="KeyboardKey" data-attr="68">' + doMathSrc("∑↙{n}{x}").outerHTML + '</span>',
       //'<div class="KeyboardRow">',
       //'<span class="KeyboardKey" data-attr="69">' + doMathSrc("∑↙{k}(\\table n;k)").outerHTML + '</span>',
       //'<span class="KeyboardKey" data-attr="70">' + doMathSrc("∑↙{i=0}↖n{x}").outerHTML + '</span>',
       //'<span class="KeyboardKey" data-attr="71">' + doMathSrc("∑↙{0⋜i⋜m}↙{0⋜j⋜m}↖n{P(i,j)}").outerHTML + '</span>',
       //'</div>',
       //'</div>',
       //'</div>'
    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
    leftMenu.empty();
    leftMenu.append('<span>' + doMathSrc("∑↙{i=0}↖n").outerHTML + '</span>');
    leftMenu.append('<span onclick="return defaultScientific_KeyBoard();">SK</span>');
    leftMenu.append('<span onclick="return gotoQWETY();">QK</span>');
}


function gotoEmoji() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');


    var keys = [
        '<span class="KeyboardKey" data-attr="107" data-src="assets/custom/KeyboardIcons/images/emojies/e1.gif"> <a href="javascript:;" class="emojiesbutton"><img src="assets/custom/KeyboardIcons/images/emojies/e1.gif" /></a></span>',
        '<span class="KeyboardKey" data-attr="107" data-src="assets/custom/KeyboardIcons/images/emojies/e2.gif"> <a href="javascript:;" class="emojiesbutton"><img src="assets/custom/KeyboardIcons/images/emojies/e2.gif" /></a></span>',
        '<span class="KeyboardKey" data-attr="107" data-src="assets/custom/KeyboardIcons/images/emojies/e3.gif"> <a href="javascript:;" class="emojiesbutton"><img src="assets/custom/KeyboardIcons/images/emojies/e3.gif" /></a></span>',
        '<span class="KeyboardKey" data-attr="107" data-src="assets/custom/KeyboardIcons/images/emojies/e4.gif"> <a href="javascript:;" class="emojiesbutton"><img src="assets/custom/KeyboardIcons/images/emojies/e4.gif" /></a></span>',

        '<span class="KeyboardKey" data-attr="107" data-src="assets/custom/KeyboardIcons/images/emojies/e5.gif"> <a href="javascript:;" class="emojiesbutton"><img src="assets/custom/KeyboardIcons/images/emojies/e5.gif" /></a></span>',
        '<span class="KeyboardKey" data-attr="107" data-src="assets/custom/KeyboardIcons/images/emojies/e6.gif"> <a href="javascript:;" class="emojiesbutton"><img src="assets/custom/KeyboardIcons/images/emojies/e6.gif" /></a></span>',
        '<span class="KeyboardKey" data-attr="107" data-src="assets/custom/KeyboardIcons/images/emojies/e7.gif"> <a href="javascript:;" class="emojiesbutton"><img src="assets/custom/KeyboardIcons/images/emojies/e7.gif" /></a></span>',
        '<span class="KeyboardKey" data-attr="107" data-src="assets/custom/KeyboardIcons/images/emojies/e8.gif"> <a href="javascript:;" class="emojiesbutton"><img src="assets/custom/KeyboardIcons/images/emojies/e8.gif" /></a></span>',
         '<span class="KeyboardKey" data-attr="107" data-src="assets/custom/KeyboardIcons/images/emojies/e9.gif"> <a href="javascript:;" class="emojiesbutton"><img src="assets/custom/KeyboardIcons/images/emojies/e9.gif" /></a></span>',
 '<span class="KeyboardKey" data-attr="107" data-src="assets/custom/KeyboardIcons/images/emojies/e10.gif"> <a href="javascript:;" class="emojiesbutton"><img src="assets/custom/KeyboardIcons/images/emojies/e10.gif" /></a></span>',
 '<span class="KeyboardKey" data-attr="107" data-src="assets/custom/KeyboardIcons/images/emojies/e11.gif"> <a href="javascript:;" class="emojiesbutton"><img src="assets/custom/KeyboardIcons/images/emojies/e11.gif" /></a></span>',
 '<span class="KeyboardKey" data-attr="107" data-src="assets/custom/KeyboardIcons/images/emojies/e12.gif"> <a href="javascript:;" class="emojiesbutton"><img src="assets/custom/KeyboardIcons/images/emojies/e12.gif" /></a></span>',
 '<span class="KeyboardKey" data-attr="107" data-src="assets/custom/KeyboardIcons/images/emojies/e13.gif"> <a href="javascript:;" class="emojiesbutton"><img src="assets/custom/KeyboardIcons/images/emojies/e13.gif" /></a></span>',
 '<span class="KeyboardKey" data-attr="107" data-src="assets/custom/KeyboardIcons/images/emojies/e14.gif"> <a href="javascript:;" class="emojiesbutton"><img src="assets/custom/KeyboardIcons/images/emojies/e14.gif" /></a></span>',
 '<span class="KeyboardKey" data-attr="107" data-src="assets/custom/KeyboardIcons/images/emojies/e15.gif"> <a href="javascript:;" class="emojiesbutton"><img src="assets/custom/KeyboardIcons/images/emojies/e15.gif" /></a></span>',
 '<span class="KeyboardKey" data-attr="107" data-src="assets/custom/KeyboardIcons/images/emojies/e16.gif"> <a href="javascript:;" class="emojiesbutton"><img src="assets/custom/KeyboardIcons/images/emojies/e16.gif" /></a></span>',


    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));

}

function gotoForAllSym() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [
        '<span class="KeyboardKey" data-attr="72" data-text="V"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/vimages/vimg1.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="73" data-text="V"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/vimages/vimg2.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="74" data-text="V"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/vimages/v1.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="75" data-text="⋀"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/tiltvimages/tiltvimg1.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="76" data-text="⋀"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/tiltvimages/tiltvimg2.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="77" data-text="⋀"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/vimages/v2.png" /></a></span>',
       //'<div class="keyboard" data-attr="SCIENTIFIC_MAIN">',
       //'<div class="KeyboardRow">',
       //'<span class="KeyboardKey" data-attr="72">' + doMathSrc("⋁x").outerHTML + '</span>',
       //'<span class="KeyboardKey" data-attr="73">' + doMathSrc("⋁↙{-x}↖{x}{y}").outerHTML + '</span>',
       //'<span class="KeyboardKey" data-attr="74">' + doMathSrc("⋁↖{x}{y}").outerHTML + '</span>',
       //'<div class="KeyboardRow">',
       //'<span class="KeyboardKey" data-attr="75">' + doMathSrc("⋀x").outerHTML + '</span>',
       //'<span class="KeyboardKey" data-attr="76">' + doMathSrc("⋀↙{-x}↖{x}{y}").outerHTML + '</span>',
       //'<span class="KeyboardKey" data-attr="77">' + doMathSrc("⋀↖{x}{y}").outerHTML + '</span>',
       //'</div>',
       //'</div>',
       //'</div>'
    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
    leftMenu.empty();
    leftMenu.append('<span>' + doMathSrc("⋁").outerHTML + '</span>');
    leftMenu.append('<span onclick="return defaultScientific_KeyBoard();">SK</span>');
    leftMenu.append('<span onclick="return gotoQWETY();">QK</span>');
}


function gotoForUSym() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [
        '<span class="KeyboardKey" data-attr="72" data-text="U"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/uimages/ui1.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="73" data-text="U"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/uimages/u2.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="74" data-text="U"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/uimages/u3.png" /></a></span>',


    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
    leftMenu.empty();
    leftMenu.append('<span>' + doMathSrc("⋁").outerHTML + '</span>');
    leftMenu.append('<span onclick="return defaultScientific_KeyBoard();">SK</span>');
    leftMenu.append('<span onclick="return gotoQWETY();">QK</span>');
}

function gotoFortiltUSym() {
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [
        '<span class="KeyboardKey" data-attr="75" data-text="∩"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/tilteduimages/invertedu1.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="76" data-text="∩"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/tilteduimages/invertedu2.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="77" data-text="∩"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/tilteduimages/invertedu3.png" /></a></span>',


    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));
    leftMenu.empty();
    leftMenu.append('<span>' + doMathSrc("⋁").outerHTML + '</span>');
    leftMenu.append('<span onclick="return defaultScientific_KeyBoard();">SK</span>');
    leftMenu.append('<span onclick="return gotoQWETY();">QK</span>');
}

function gotoQWETY() {
    preserveCount = 0;
    $('#commonKeys').hide();
    var keyboard = $('#keyboadArea');
    var editor = $('#editor');
    var leftMenu = $('#leftSideMenu');
    var rightMenu = $('#rightSideMenu');

    var keys = [
        '<div class="qwerty">',
        '<div style="text-align:center">',
          '<span class="KeyboardKey" data-attr="80" data-text="1"> <a href="javascript:;" class="button" onclick="android.sendKeys()"><img src="assets/custom/KeyboardIcons/images/special character/on.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="80" data-text="2"> <a href="javascript:;" class="button" onclick="android.sendKeys()"><img src="assets/custom/KeyboardIcons/images/special character/two.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="80" data-text="3"> <a href="javascript:;" class="button" onclick="android.sendKeys()"><img src="assets/custom/KeyboardIcons/images/special character/three.png" /></a></span>',
     '<span class="KeyboardKey" data-attr="80" data-text="4"> <a href="javascript:;" class="button" onclick="android.sendKeys()"><img src="assets/custom/KeyboardIcons/images/special character/four.png" /></a></span>',
      '<span class="KeyboardKey" data-attr="80" data-text="5"> <a href="javascript:;" class="button" onclick="android.sendKeys()"><img src="assets/custom/KeyboardIcons/images/special character/five.png" /></a></span>',
       '<span class="KeyboardKey" data-attr="80" data-text="6"> <a href="javascript:;" class="button" ><img src="assets/custom/KeyboardIcons/images/special character/six.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="7"> <a href="javascript:;" class="button" ><img src="assets/custom/KeyboardIcons/images/special character/seven.png" /></a></span>',
         '<span class="KeyboardKey" data-attr="80" data-text="8"> <a href="javascript:;" class="button" ><img src="assets/custom/KeyboardIcons/images/special character/eight.png" /></a></span>',
          '<span class="KeyboardKey" data-attr="80" data-text="9"> <a href="javascript:;" class="button" ><img src="assets/custom/KeyboardIcons/images/special character/nine.png" /></a></span>',
           '<span class="KeyboardKey" data-attr="80" data-text="0"> <a href="javascript:;" class="button" ><img src="assets/custom/KeyboardIcons/images/special character/zero.png" /></a></span>',
'</div>',
'<div class="smallLetters">',
         '<div style="text-align:center">',


        '<span class="KeyboardKey" data-attr="80" data-text="q"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/q.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="w"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/w.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="e"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/e.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="r"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/r.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="t"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/t.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="y"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/y.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="u"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/u.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="i"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/i1.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="o"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/o.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="p"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/p.png" /></a></span>',

         '</div>',
       '<div style="text-align:center">',
        '<span class="KeyboardKey" data-attr="80" data-text="a"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/a3.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="s"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/s.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="d"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/d.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="f"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/f.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="g"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/g.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="h"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/h1.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="j"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/j.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="k"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/k.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="l"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/l.png" /></a></span>',
        '<span class="" onclick="backspaceFunction()"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/bksp.png" /></a></span>',

         '</div>',
          '<div style="text-align:center">',
          '<span onclick="loadCapitalLetters()"> <a href="javascript:;" class="button" ><img src="assets/custom/KeyboardIcons/images/special character/shift3.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="z"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/z.png" /></a></span>',

        '<span class="KeyboardKey" data-attr="80" data-text="x"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/x.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="c"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/c.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="v"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/v.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="b"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/b.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="n"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/n.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="m"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/small-letters/m.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="<br/>"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/enter.png" /></a></span>',


          '</div>',
          '</div>',
           '</div>',
          '<div style="text-align:center">',
        '<span class="KeyboardKey" data-attr="80" data-text="?"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/QUESTIONMARK.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="&nbsp;"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/space.png" /></a></span>',
        '<span class="KeyboardKey" data-attr="80" data-text="."> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/dot.png" /></a></span>',
          '<span class="" onclick="deleteFunction()"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/del.png" /></a></span>',
         '</div>',


    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));

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
    $('#commonKeys').hide();
    var keyboard = $('#keyboadArea');



    var keys = [
        '<div class="sp">',
    '<span class="KeyboardKey" data-attr="1"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/img1.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="2"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/im2.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="3"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/im3.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="4"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/img4.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="5"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/img5.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="6"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/img6.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="7"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/im7.png" /></a></span>',

    '<span class="KeyboardKey" data-attr="8"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/img8.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="9"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/img9.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="10"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/img10.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="11"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/img11.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="12"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/img12.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="115" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/img13.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="114" > <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/img14.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="15"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/img15.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="124"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/im124.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="125"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/im125.png" /></a></span>',
    '</div>'
    ];
    keyboard.children().remove();
    keyboard.append(keys.join(''));








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
            //te.focus();
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



    pasteHtmlAtCaret(t);





}



$(function () {
  M.trustHtml = true;
  jQuery('#mathSrc1').keyup(F(doMathSrc1, 1)).mouseup(F(doMathSrc1, 1));
    //jQuery('#mathSrc2').keyup(F(doMathSrc1, 2)).mouseup(F(doMathSrc1, 2));
    jQuery('table.prec-form-char td:last-child')
		.addClass('fm-mo')
		.mouseover(checkUnicodeTitle)
		.click(insertToSrc2);


});

function AddTextBox(value) {
    M.trustHtml = true;

    doMathSrc1(value);
    // jQuery('#mathSrc1').keyup(F(doMathSrc1, 1)).mouseup(F(doMathSrc1, 1));
    //jQuery('#mathSrc2').keyup(F(doMathSrc1, 2)).mouseup(F(doMathSrc1, 2));
    //jQuery('table.prec-form-char td:last-child')
    jQuery('span.KeyboardKey')
		.addClass('fm-mo')
		.mouseover(checkUnicodeTitle)
		.click(insertToSrc2);


}

function AddStyle_ToTextbox() {
    jQuery('#editor').find('input[type=text]').addClass('textbox');

}
function Expand(obj) {
    if (!obj.savesize) obj.savesize = obj.size;
    obj.size = Math.max(obj.savesize, obj.value.length);
}


function addSpanToMath(t) {
    jQuery('#question').html(t);

    var isIE = false;
    if (navigator.userAgent.indexOf('MSIE') !== -1 || navigator.appVersion.indexOf('Trident/') > 0) {
        isIE = true;
    }
    if (isIE) {
        jQuery('#question').find('fmath').each(function () {
            jQuery(this).replaceWith('<div class="span" ><fmath>' + jQuery(this).html() + '</fmath></div>&nbsp;&nbsp;');
        });
    }
    else if (jQuery.browser.mozilla == true) {
        jQuery('#question').find('math').each(function () {
            jQuery(this).replaceWith('<div class="span" ><math>' + jQuery(this).html() + '</math></div>&nbsp;&nbsp;');
        });
    }
    else {
        jQuery('#question').find('fmath').each(function () {
            jQuery(this).replaceWith('<div class="span" ><fmath>' + jQuery(this).html() + '</fmath></div>&nbsp;&nbsp;');
        });
    }


}




function pasteHtmlAtCaret(html) {

    jQuery('#question').html(html);

    var isIE = false;
    if (navigator.userAgent.indexOf('MSIE') !== -1 || navigator.appVersion.indexOf('Trident/') > 0) {
        isIE = true;
    }

    if (isIE) {
        jQuery('#question').find('fmath').each(function () {
            jQuery(this).replaceWith('<div class="span" ><fmath>' + jQuery(this).html() + '</fmath></div>&nbsp;&nbsp;');
        });
    }
    else if (jQuery.browser.mozilla == true) {
        jQuery('#question').find('math').each(function () {
            jQuery(this).replaceWith('<div class="span" ><math>' + jQuery(this).html() + '</math></div>&nbsp;&nbsp;');
        });
    }
    else {
        jQuery('#question').find('fmath').each(function () {
            $(this).replaceWith('<div class="span" ><fmath>' + $(this).html() + '</fmath></div>&nbsp;&nbsp;');
        });
    }
    html = $('#question').html();
    if ($('#editor').find('.add').length > 0) {



        if ($('.add').html().length > 0) {
            appendTextAtCaret(html);
        }
        else {
            $('.add').addClass('text');
            $('.add').append($('#question').html());
            $('.add').find('br').remove();
        }


    }
    else {
        appendTextAtCaret(html);
    }


    //position = getCaretPosition(document.getElementById('editor'));
    //alert(position);
    //setCaret();
}

function appendTextAtCaret(html) {
    var sel, range;
    if (window.getSelection) {

        // IE9 and non-IE
        sel = window.getSelection();

        if (sel.getRangeAt && sel.rangeCount) {
            range = sel.getRangeAt(0);
            range.deleteContents();

            // Range.createContextualFragment() would be useful here but is
            // non-standard and not supported in all browsers (IE9, for one)
            var el = document.createElement("div");
            el.innerHTML = html;

            var frag = document.createDocumentFragment(), node, lastNode;

            while ((node = el.firstChild)) {

                lastNode = frag.appendChild(node);
            }

            range.insertNode(frag);

            // Preserve the selection
            if (lastNode) {
                range = range.cloneRange();
                range.setStartAfter(lastNode);
                range.collapse(true);
                sel.removeAllRanges();
                sel.addRange(range);
            }
        }
    } else if (document.selection && document.selection.type != "Control") {
        // IE < 9

        document.selection.createRange().pasteHTML(html);
    }
}

function appendEquationFor52() {

    var isIE = false;
    var html = "";
    if (navigator.userAgent.indexOf('MSIE') !== -1 || navigator.appVersion.indexOf('Trident/') > 0) {
        isIE = true;
    }

    if (isIE) {

        html = '<div class="span" ><fmath><mrow><mo>{</mo><mtext><div class="textbox"></div></mtext><mo>}</mo></mrow></fmath></div>&nbsp;&nbsp;';

    }
    else if ($.browser.mozilla == true) {
        html = '<div class="span" ><math><mrow><mo>{</mo><mtext><div class="textbox"></div></mtext><mo>}</mo></mrow></math></div>&nbsp;&nbsp;';
    }
    else {
        html = '<div class="span" ><fmath><mrow><mo>{</mo><mtext><div class="textbox"></div></mtext><mo>}</mo></mrow></fmath></div>&nbsp;&nbsp;';
    }
    var sel, range;
    if (window.getSelection) {
        // IE9 and non-IE
        sel = window.getSelection();
        if (sel.getRangeAt && sel.rangeCount) {
            range = sel.getRangeAt(0);
            range.deleteContents();

            // Range.createContextualFragment() would be useful here but is
            // non-standard and not supported in all browsers (IE9, for one)
            var el = document.createElement("div");
            el.innerHTML = html;

            var frag = document.createDocumentFragment(), node, lastNode;

            while ((node = el.firstChild)) {

                lastNode = frag.appendChild(node);
            }

            range.insertNode(frag);

            // Preserve the selection
            if (lastNode) {
                range = range.cloneRange();
                range.setStartAfter(lastNode);
                range.collapse(true);
                sel.removeAllRanges();
                sel.addRange(range);
            }
        }
    } else if (document.selection && document.selection.type != "Control") {
        // IE < 9
        alert();
        document.selection.createRange().pasteHTML(html);
    }
    $('.add').addClass('text');
    $('.textbox').find('br').remove();
}

function appendEquationFor56() {

    var isIE = false;
    var html = "";
    if (navigator.userAgent.indexOf('MSIE') !== -1 || navigator.appVersion.indexOf('Trident/') > 0) {
        isIE = true;
    }

    if (isIE) {

        html = '<div class="span" ><fmath><mrow><mo>{</mo><mtext><div  class="textbox"></div></mtext><mo>|</mo><mtext><div class="textbox"></div></mtext><mo>}</mo></mrow></fmath></div>&nbsp;&nbsp;';

    }
    else if ($.browser.mozilla == true) {
        html = '<div class="span" ><fmath><mrow><mo>{</mo><mtext><div class="textbox"></div></mtext><mo>|</mo><mtext><div class="textbox"></div></mtext><mo>}</mo></mrow></fmath></div>&nbsp;&nbsp;';
    }
    else {
        html = '<div class="span" ><math><mrow><mo>{</mo><mtext><div class="textbox"></div></mtext><mo>|</mo><mtext><div class="textbox"></div></mtext><mo>}</mo></mrow></math></div>&nbsp;&nbsp;';
    }

    var sel, range;
    if (window.getSelection) {
        // IE9 and non-IE
        sel = window.getSelection();
        if (sel.getRangeAt && sel.rangeCount) {
            range = sel.getRangeAt(0);
            range.deleteContents();

            // Range.createContextualFragment() would be useful here but is
            // non-standard and not supported in all browsers (IE9, for one)
            var el = document.createElement("div");
            el.innerHTML = html;

            var frag = document.createDocumentFragment(), node, lastNode;

            while ((node = el.firstChild)) {

                lastNode = frag.appendChild(node);
            }

            range.insertNode(frag);

            // Preserve the selection
            if (lastNode) {
                range = range.cloneRange();
                range.setStartAfter(lastNode);
                range.collapse(true);
                sel.removeAllRanges();
                sel.addRange(range);
            }
        }
    } else if (document.selection && document.selection.type != "Control") {
        // IE < 9

        document.selection.createRange().pasteHTML(html);
    }
    $('.add').addClass('text');
    $('.textbox').find('br').remove();
}


function addSymbolToEditor(symbol) {


    var html = "<mrow><mo><div class='textbox'></div></mo><mo>" + symbol + "</mo><mo><div  class='textbox'></div></mo></mrow>";


    var isIE = false;

    if (navigator.userAgent.indexOf('MSIE') !== -1 || navigator.appVersion.indexOf('Trident/') > 0) {
        isIE = true;
    }

    if (isIE) {

        html = '<div class="span" ><fmath>' + html + '</fmath></div>&nbsp;&nbsp;';

    }
    else if ($.browser.mozilla == true) {
        html = '<div class="span" ><math>' + html + '</math></div>&nbsp;&nbsp;';
    }
    else {
        html = '<div class="span" ><fmath>' + html + '</fmath></div>&nbsp;&nbsp;';
    }

    var sel, range;
    if (window.getSelection) {
        // IE9 and non-IE
        sel = window.getSelection();
        if (sel.getRangeAt && sel.rangeCount) {
            range = sel.getRangeAt(0);
            range.deleteContents();

            // Range.createContextualFragment() would be useful here but is
            // non-standard and not supported in all browsers (IE9, for one)
            var el = document.createElement("div");
            el.innerHTML = html;

            var frag = document.createDocumentFragment(), node, lastNode;

            while ((node = el.firstChild)) {

                lastNode = frag.appendChild(node);
            }

            range.insertNode(frag);

            // Preserve the selection
            if (lastNode) {
                range = range.cloneRange();
                range.setStartAfter(lastNode);
                range.collapse(true);
                sel.removeAllRanges();
                sel.addRange(range);
            }
        }
    } else if (document.selection && document.selection.type != "Control") {
        // IE < 9

        document.selection.createRange().pasteHTML(html);
    }
    $('.add').addClass('text');
    $('.textbox').find('br').remove();
}

function backspace() {
    p = document.getElementById("editor");
    c = getCaretPosition(p);

    str = $("#editor").html();
    if (c > 0 && c <= str.length) {
        $("#editor").focus().html(str.substring(0, c - 1) + str.substring(c, str.length));
       // p.focus();
        var textNode = p.firstChild;
        var caret = c - 1;
        var range = document.createRange();
        range.setStart(textNode, caret);
        range.setEnd(textNode, caret);
        var sel = window.getSelection();
        sel.removeAllRanges();
        sel.addRange(range);
    }
}

$.fn.setCursorPosition = function (pos) {
    this.each(function (index, elem) {
        if (elem.setSelectionRange) {
            elem.setSelectionRange(pos, pos);
        } else if (elem.createTextRange) {
            var range = elem.createTextRange();
            range.collapse(true);
            range.moveEnd('character', pos);
            range.moveStart('character', pos);
            range.select();
        }
    });
    return this;
};

function getCaretPosition(editableDiv) {
    var caretPos = 0,
      sel, range;
    if (window.getSelection) {
        sel = window.getSelection();
        if (sel.rangeCount) {
            range = sel.getRangeAt(0);
            if (range.commonAncestorContainer.parentNode == editableDiv) {
                caretPos = range.endOffset;
            }
        }
    } else if (document.selection && document.selection.createRange) {
        range = document.selection.createRange();
        if (range.parentElement() == editableDiv) {
            var tempEl = document.createElement("span");
            editableDiv.insertBefore(tempEl, editableDiv.firstChild);
            var tempRange = range.duplicate();
            tempRange.moveToElementText(tempEl);
            tempRange.setEndPoint("EndToEnd", range);
            caretPos = tempRange.text.length;
        }
    }
    return caretPos;
}



var datahtml = "";


$(document).ready(function () {
    $("#1").click(function () {

        var userID = $('#hdnUserID').val();
        var pageID = $('#hdnPageID').val();
        var question = $('#hdnQuestionID').val();
        var vps = encodeURIComponent(datahtml);
        $.ajax({
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            url: "/Home/SaveQuestion",
            data: '{ "userID" : "' + userID + '","pageID":"' + pageID + '","data":"' + vps + '","question":"' + question + '" }',
            
            dataType: "JSON",
            success: function (data) {
                if (data.success) {
                    alert("Done")
                }
                else {
                    $('#messagespan').html('error in request please try again later');

                };
            }
        });
    })

})


function GetData() {

    //$("#editor").find('.textbox').replaceWith($(this).html());
    while ($("#editor").find('div').length > 0) {
        $("#editor").find('div').each(function () {
            var data = $(this).html();

            $(this).replaceWith(data);

        });
    }

    datahtml = $("#editor").html();
    //alert(datahtml);
    if (datahtml.length > 0) {
        $('#data').html(datahtml);

        return false;
        //SaveData();
        //$('#questionsDiv').removeClass('short');
        //$('.content').hide();
    }
    else {
        alert('Please enter any text');
        return false;
    }

}




function SaveData() {
    var userID = $('#hdnUserID').val();
    var pageID = $('#hdnPageID').val();
    var question = $('#hdnQuestionID').val();

    var vps = encodeURIComponent(datahtml);


    if (datahtml != '') {
        $.ajax({
            type: 'POST',
            url: '/Home/SaveQuestion',
            data: '{ "userID" : "' + userID + '","pageID":"' + pageID + '","data":"' + vps + '","question":"' + question + '" }',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {
                if (data.success) {
                    $('#messagespan').html('Record Saved successfuly!!');
                    //$('#questionsDiv').load("/Home/_QuestionList?userId=" + userID + "&pageId=" + pageID + "");
                }
                else {
                    $('#messagespan').html('error in request please try again later');

                };
            }
        });
    }

}

function appendEquationFor107(img) {

    var html = "";

    html = '<div class="span" >' + img + '</div>&nbsp;&nbsp;';


    var sel, range;
    if (window.getSelection) {
        // IE9 and non-IE
        sel = window.getSelection();
        if (sel.getRangeAt && sel.rangeCount) {
            range = sel.getRangeAt(0);
            range.deleteContents();

            // Range.createContextualFragment() would be useful here but is
            // non-standard and not supported in all browsers (IE9, for one)
            var el = document.createElement("div");
            el.innerHTML = html;

            var frag = document.createDocumentFragment(), node, lastNode;

            while ((node = el.firstChild)) {

                lastNode = frag.appendChild(node);
            }

            range.insertNode(frag);

            // Preserve the selection
            if (lastNode) {
                range = range.cloneRange();
                range.setStartAfter(lastNode);
                range.collapse(true);
                sel.removeAllRanges();
                sel.addRange(range);
            }
        }
    } else if (document.selection && document.selection.type != "Control") {
        // IE < 9

        document.selection.createRange().pasteHTML(html);
    }
    $('.add').addClass('text');
    $('.textbox').find('br').remove();
}

function loadCapitalLetters() {
    if (preserveCount < 2) {
        preserveCount++;
    }
    var keys = ['<div style="text-align:center">',


    '<span class="KeyboardKey" data-attr="161" data-text="Q"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/q.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="W"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/w.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="E"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/e.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="R"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/r.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="T"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/t.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="Y"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/y.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="U"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/u.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="I"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/i.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="O"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/o.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="P"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/p.png" /></a></span>',

     '</div>',
   '<div style="text-align:center">',
    '<span class="KeyboardKey" data-attr="161" data-text="A"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/a.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="S"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/s.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="D"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/d.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="F"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/f.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="G"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/g.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="H"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/h.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="J"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/j.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="K"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/k.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="L"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/l.png" /></a></span>',

     '<span class="" onclick="backspaceFunction()"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/bksp.png" /></a></span>',
     '</div>',
      '<div style="text-align:center">',
        '<span class="" onclick="' + (preserveCount < 2 ? "loadCapitalLetters()" : "gotoQWETY()") + '"> <a href="javascript:;" class="button" style="background: linear-gradient(to bottom, rgb(6, 106, 204) 12%, rgb(8, 90, 173) 67%);"><img src="assets/custom/KeyboardIcons/images/special character/shift3.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="Z"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/z.png" /></a></span>',

    '<span class="KeyboardKey" data-attr="161" data-text="X"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/x.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="C"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/c.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="V"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/v.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="B"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/b.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="N"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/n.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="M"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/querty keyboard/m.png" /></a></span>',
    '<span class="KeyboardKey" data-attr="161" data-text="<br/>"> <a href="javascript:;" class="button"><img src="assets/custom/KeyboardIcons/images/special character/enter.png" /></a></span>',


      '</div>'];

    $(document).find('.smallLetters').html(keys.join(''));
}











