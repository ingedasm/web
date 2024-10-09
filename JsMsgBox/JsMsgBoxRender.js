function JsMsgBox()
{
	this.Texto_Boton_OK;
	this.Texto_Boton_Cancel;
	this.Texto_Boton_Abort;
	this.Texto_Boton_Retry;
	this.Texto_Boton_Ignore;
	this.Width;
	this.Height;
	this.Texto;
	this.Icono;
	this.Botones;

	this.show = function()
	{
		///UserCodeRegionStart:[show] (do not remove this comment.)
		
		
		
		
		
		
		
		
		
		///UserCodeRegionEnd: (do not remove this comment.)
	}
	///UserCodeRegionStart:[User Functions] (do not remove this comment.)
	
	var myThis = this;
	
	this.Ejecutar = function()
	{
		var myHeight = this.Height;
		var myWidth = this.Width;
		
		if (myHeight.indexOf("px") == -1)
		{
			myHeight += "px";
		}
		
		if (myWidth.indexOf("px") == -1)
		{
			myWidth += "px";
		}
		
		var barColors = new Array();
		barColors["0"] = "0,0,0";
		barColors["1"] = "67,135,253"		// -- "100,100,255";
		barColors["2"] = "255,173,0";
		barColors["3"] = "198,11,68";
		barColors["4"] = "255,154,26";
		
		var buttons;
		
		var imgName = "";
		switch(this.Icono){
			case "1":	// -- Information
				imgName = "jsmsgbox_icon_info.png";
				break;
			case "2":	// -- Warning
				imgName = "jsmsgbox_icon_warn.png";
				break;
			case "3":	// -- Error
				imgName = "jsmsgbox_icon_erro.png";
				break;
			case "4":	// -- Question
				imgName = "jsmsgbox_icon_ques.png";
				break;
			default:
		}
		var vSrc = gx.util.resourceUrl(gx.basePath + gx.staticDirectory + 'JsMsgBox/images/' + imgName, true);	
		var imgIcon = '<img src="' + vSrc + '" style="height:50px; width:50px;">';
		
		switch(this.Botones){
			case "1":	// -- OkOnly
				buttons = '<input type="button" id="jsmsgbox_btnOk" value="' + myThis.Texto_Boton_OK + '" style="' + EstiloBoton() + '">';
				break;
			case "2":	// -- OkCancel
				buttons = '<input type="button" id="jsmsgbox_btnOk" value="' + myThis.Texto_Boton_OK + '" style="' + EstiloBoton() + '"><input type="button" id="jsmsgbox_btnCancel" value="' + myThis.Texto_Boton_Cancel + '" style="' + EstiloBoton() + '">';
				break;
			case "3":
				buttons = 	'<input type="button" id="jsmsgbox_btnAbort" value="' + myThis.Texto_Boton_Abort + '" style="' + EstiloBoton() + '">' + 
							'<input type="button" id="jsmsgbox_btnRetry" value="' + myThis.Texto_Boton_Retry + '" style="' + EstiloBoton() + '">' +
							'<input type="button" id="jsmsgbox_btnIgnore" value="' + myThis.Texto_Boton_Ignore + '" style="' + EstiloBoton() + '">';
				break;
		}
		
		var aux = this.Width.substring(0, this.Width.length - 2);
		var largo = aux - 70;
		var divs = '<div style="position:relative; background-color:rgb(' + barColors[this.Icono] + '); height:25px; width:100%; border-radius:10px 10px 0px 0px;"></div>' + 
					'<div style="position:relative; overflow:hidden; padding-top:10px; padding-left: 10px;">' + 
						'<div style="float:left; height:60px; width:60px;">' + imgIcon + '</div>' + 
						'<div style="float:left; text-align:left; width:' + largo + 'px;">' +
							'<span style="vertical-align:middle;">' + this.Texto + '</span>' + 
						'</div>' + 
					'</div>' + 
					'<div style="position:absolute; bottom:0; right:0; padding-bottom:20px; padding-right:10px;">' + buttons + '</div>';
		var buffer = 	'<div id="jsmaindiv">' +
						'</div>' +
						'<div id="jsboxdiv" style="margin:auto; position:absolute; ' + posBox() + ' width:' + myWidth + '; height:' + myHeight + '; min-height:150px; background:rgb(255,255,255); z-index: 200; border-radius:15px; box-shadow: 0px 8px 16px #000;">' + divs + '</div>';

		this.setHtml(buffer);

		AddEventOnClickOutOfBox();
		
		switch(this.Botones){
			case "1":	// -- OkOnly
				AddEventOnClickBtnOk();
				break;
			case "2":	// -- OkCancel
				AddEventOnClickBtnOk();
				AddEventOnClickBtnCancel();
				break;
			case "3":
				AddEventOnClickBtnAbort();
				AddEventOnClickBtnRetry();
				AddEventOnClickBtnIgnore();
				break;
		}
		
		function posBox() {
			var result = "";
			var w = window;
    		var d = document;
    		var e = d.documentElement;
    		var g = d.getElementsByTagName('body')[0];
    		var x = w.innerWidth || e.clientWidth || g.clientWidth;
    		var y = w.innerHeight|| e.clientHeight|| g.clientHeight;
			
			
			var xAux = myThis.Width.replace('px', '');
			var yAux = myThis.Height.replace('px', '');
			
			var xf = (x - xAux) / 2;
			var yf = (y - yAux) / 2;
			
			result = 'top:' + yf + 'px; left:' + xf + 'px;';

			return result;
		}
		
		function EstiloBoton(){
			
			var resultado = "";
		
			resultado = 'background-color:rgb(' + barColors[myThis.Icono] + '); box-shadow: 0px 2px 4px #555; color:white;' +
				'margin-bottom: 1px;' +
				'margin-right: 3px;' +
				'margin-top: 1px;' +
				'padding-bottom: 5px;' +
				'padding-left: 12px;' +
				'padding-right: 12px;' +
				'padding-top: 5px;' +
				'background-image: none;' +
				'border-bottom-color: #797979;' +
				'border-left-color: #797979;' +
				'border-right-color: #797979;' +
				'border-top-color: #797979;' +
				'border-style: solid;' +
				'border-width: 0px;' +
				'border-top-left-radius: 5px;' +
				'border-top-right-radius: 5px;' +
				'border-bottom-right-radius: 5px;' +
				'border-bottom-left-radius: 5px;' +
				'font-family: "Verdana";' +
				'font-size: 11px;' +
				'font-style: normal;' +
				'font-variant: normal;' +
				'font-weight: bold;' +
				'text-decoration: none;' +
				'color: white;' +
				'cursor: pointer;' +
				'text-indent: 0pt;' +
				'vertical-align: top;'
			
			return resultado;
		}
		
		function AddEventOnClickBtnOk()
		{
			document.getElementById("jsmsgbox_btnOk").onclick = function(){
				CloseJSMsgBox();
				myThis.OnClickOk();
			}
		}
		
		function AddEventOnClickBtnCancel()
		{
			document.getElementById("jsmsgbox_btnCancel").onclick = function(){
				CloseJSMsgBox();
				myThis.OnClickCancel();
			}
		}
		
		function AddEventOnClickBtnAbort()
		{
			document.getElementById("jsmsgbox_btnAbort").onclick = function(){
				CloseJSMsgBox();
				myThis.OnClickAbort();
			}
		}
		
		function AddEventOnClickBtnRetry()
		{
			document.getElementById("jsmsgbox_btnRetry").onclick = function(){
				CloseJSMsgBox();
				myThis.OnClickRetry();
			}
		}
		
		function AddEventOnClickBtnIgnore()
		{
			document.getElementById("jsmsgbox_btnIgnore").onclick = function(){
				CloseJSMsgBox();
				myThis.OnClickIgnore();
			}
		}
		
		function AddEventOnClickOutOfBox()
		{
			document.getElementById("jsmaindiv").onclick = function(){
				CloseJSMsgBox();
			}			
		
		}
		
		function CloseJSMsgBox(){
			document.getElementById("jsmaindiv").style.display = 'none';
			document.getElementById("jsboxdiv").style.display = 'none';
		}
		
	}	
	
	///UserCodeRegionEnd: (do not remove this comment.):
}
