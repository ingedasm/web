function scaProgressBar()
{
	this.Height;
	this.Width;
	this.BackgroundColor;
	this.FontColor;
	this.Borders;
	this.ProgressColor;
	this.ProcessId;
	this.Interval;
	this.Progress;
	this.UpdateProgressURL;
	this.SubmitProgressURL;

	this.show = function()
	{
	
		
		if (!this.IsPostBack){
			if (this.Progress == "")
				this.Progress = "0";
				
			var buffer = new gx.text.stringBuffer();
			// Customize
			var borderRadius = 0;
			if (this.Borders == 1)borderRadius = 15;
			buffer.clear();
						
			buffer.append('<div align="left" style="border-radius: '+ borderRadius +'px;color:rgb(' +  this.FontColor.R + ',' + this.FontColor.G + ',' + this.FontColor.B + '); background:rgb(' +  this.BackgroundColor.R + ',' + this.BackgroundColor.G + ',' + this.BackgroundColor.B + '); width:' + this.Width +'; height:' + this.Height + ';" id="' + this.ControlName + '" class="progress-container">');
			var margin_text = (this.Height - 16)/2;
			buffer.append('<span  id="' + this.ContainerName + '_bar' + 'progress_text" style="margin-top: '+ margin_text +'px; ">'+ this.Progress +'%</span>');//bordes  y color de la progress
			buffer.append('<div  id="' + this.ContainerName + '_bar' + 'progress_bar" style="width: '+ this.Progress +'%'  +'; height:' + this.Height + ' ;border-radius: '+ borderRadius +'px;background-color:rgb(' +  this.ProgressColor.R + ',' + this.ProgressColor.G + ',' + this.ProgressColor.B + ');"></div>');
			buffer.append('</div>');
			this.setHtml(buffer.toString()); 
		}		
		
		
		
	}
	
	this.AjaxGxProc= function(URL, changeProgress)
	{
		var xmlhttp;
		if (window.XMLHttpRequest)
  		{// code for IE7+, Firefox, Chrome, Opera, Safari
  			xmlhttp=new XMLHttpRequest();
  		}
		else
		{// code for IE6, IE5
  			xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
  		}
  		
		
		xmlhttp.open("POST", URL, false);
		xmlhttp.send();
		
		if(changeProgress==true)
		{
			this.SetProgress(xmlhttp.responseText);			
		}
	}
	
	this.Start = function(){
	if (!((this.SubmitProgressURL==undefined) || (this.SubmitProgressURL==""))){
	   this.AjaxGxProc(this.SubmitProgressURL, false);
	   	}
	   if ((this.UpdateProgressURL==undefined) || (this.UpdateProgressURL=="")){
 		this.timer = setInterval(this.doProgressBar.closure(this), this.Interval * 1000);
	   } else {
		 this.timer = setInterval(this.doAjaxProgressBar.closure(this), this.Interval * 1000);
	   }
	}
	
	
	this.SetProgress = function(actualprogress){
		if(typeof String.prototype.trim !== 'function') {
  			String.prototype.trim = function() {
    		return this.replace(/^\s+|\s+$/g, ''); 
  			}
		}
		this.Progress = actualprogress.trim();
		var completed = this.Progress;   
			if (parseInt(completed) < 100) {
				gx.dom.byId(this.ContainerName + '_bar' + 'progress_text').innerHTML = completed + "%";
				gx.dom.byId(this.ContainerName + '_bar' + 'progress_bar').style.width = completed + "%";
			}else{
			if (parseInt(completed) == 100) {
				gx.dom.byId(this.ContainerName + '_bar' + 'progress_text').innerHTML = "100%";
				gx.dom.byId(this.ContainerName + '_bar' + 'progress_bar').style.width = "100%";
				clearInterval(this.timer);	
				if (this.OnComplete){
					this.OnComplete();
				} }
			}
	}
			
	this.doProgressBar = function(){
		if (this.UpdateProgress){
			this.UpdateProgress();
		}
		this.SetProgress(this.Progress);
	}
	
	this.doAjaxProgressBar = function(){
		this.AjaxGxProc(this.UpdateProgressURL, true);		
	}
	
}
