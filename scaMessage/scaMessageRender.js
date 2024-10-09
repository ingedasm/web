function scaMessage()
{
	this.Width;
	this.Height;
	this.MessageType;
	this.AnimationType;
	this.DelayUntilClose;
	this.AutoClose;
	this.DisplayHistoryMenu;
	this.ShowCloseButton;
	this.StartPosition;
	this.NextMessagePosition;
	this.NiftyMessageTitleTag
	this.NiftyAnimationType

	this.show = function() {
	    gx.fx.obs.addObserver('gx.onmessages', this, this.showMessages);
	    if (!this.IsPostBack) {
	    	if (this.MessageType == "niftymodal"){
	    		
	    	}
	        var divErrors = jQuery('#gxErrorViewer').children();
	        var msgsArr = [];
	        jQuery.each(divErrors, function(index, value) {
	            msgsArr.push({ att: '', type: 0, text: jQuery(value).html() });
	        });
	        var msgs = {};
	        msgs['MAIN'] = msgsArr;
	        this.showMessages(msgs);
	    } else {
	    	try {
	    		jQuery("[id*=gxErrorViewer]").remove();
	    	} catch (ERROR) {
	    		
	    	}
	    }
	    gx.evt.on_ready(this, this.removeErrorViewers);
	}

	this.removeErrorViewers = function() {
		
		jQuery("[id*=gxErrorViewer]").remove();
		
		//set nifty styles
		jQuery(
			'<style type="text/css">\n'
			+ "#" + "modal-" + this.ContainerName + " .md-content  {background-color:"+ this.NiftyMessageBackgroundColor.Html +";}\n"
			//+ " .md-modal a  {background-color:"+ this.NiftyButtonColor.Html +"; color:"+ this.NiftyMessageTextColor.Html +";}\n"
			//+ " .md-modal a:hover {background-color:"+ this.NiftyButtonHoverColor.Html +";}\n"
			+ "#" + "modal-" + this.ContainerName + " .md-content {color:"+ this.NiftyMessageTextColor.Html +";}\n"
		
			+ "#" + "md-close-"+ this.ContainerName + " {background-color:"+ this.NiftyButtonColor.Html +"; color:"+ this.NiftyMessageTextColor.Html +";}\n"
			+ "#" + "md-close-"+ this.ContainerName + ":hover {background-color:"+ this.NiftyButtonHoverColor.Html +";}\n"
		
			+ " modal-" + this.ContainerName + " .codrops-top {background-color:"+ this.NiftyMessageBackgroundColor +"; color:"+this.NiftyMessageTextColor.Html+"}\n"
			+ " modal-" + this.ContainerName + " .md-modal-title {background-color:"+ this.NiftyMessageBackgroundColor+"; color:" + this.NiftyMessageTextColor.Html+"}\n"
			
			+ " .md-modal {font-family: "+ this.NiftyMessageFontFamily +"}"
			+ '</style>'	
		).appendTo("head");
		
	}
	
	this.showMessages = function(messages) {
		
	    switch (this.MessageType) {
	    	case "bootstrap":
	        case "pinesnotify":
	        	for (var key in messages) {
	        		if (key != undefined){
				  		this.renderPinesNotify(messages[key]);
				  	}
				}
	            break;
	        case "niftymodal":
	        	for (var key in messages) {
	        		if (key != undefined){
				  		this.renderNiftyModal(messages[key]);
				  	}
				}
	            break;    
	        case "dialog":
	        	for (var key in messages) {
	        		if (key != undefined){
				  		this.renderDialog(messages[key]);
				  	}
				}
	            break;
	        case "alert":
	            for (var key in messages) {
	        		if (key != undefined){
				  		this.renderAlert(messages[key]);
				  	}
				}
	            break;
	    }
	}
	
	this.renderPinesNotify = function(messages) {
		
		var _mthis = this;
		var _stack  = jQuery.pnotify.defaults.pnotify_stack;
		_stack.dir1 = _mthis.NextMessagePosition;
		
		var _notifyclass = "";
		switch(this.StartPosition)
		{
			case "TopCenter":
  				_notifyclass = "stack-topcenter";
  				break;
			case "TopLeft":
  				_notifyclass = "stack-topleft";
  				break;
  			case "TopRight":
  				_notifyclass = "stack-topright";
  				break;	
  			case "BottomRight":
  				_notifyclass = "stack-bottomright";
  				break;
  			case "BottomCenter":
  				_notifyclass = "stack-bottomcenter";
  				break;
  			case "BottomLeft":
  				_notifyclass = "stack-bottomleft";
  				break;
		}
		
		var messagesContainer = messages
		if (messages.msgs) messagesContainer = messages.msgs
		
	    jQuery.each(messagesContainer, function(index, value) {
	    		if (!value.text) return;
	    			
	        	var type = 'info'
	        	if (value.type === 1){
	        		type = 'error'
	        	} 
	            var notif = jQuery.pnotify({ pnotify_text:  value.text.replace(/</g,"&lt;"), 
	            	pnotify_animation:     _mthis.AnimationType,
	            	pnotify_animate_speed: _mthis.AnimationSpeed,      //speed of closing and opening effects
	            	pnotify_delay:         _mthis.DelayUntilClose,     //time until close the message
	            	pnotify_hide:          _mthis.AutoClose,           //close automatically the messsage or forse te user to closed it
	            	pnotify_history:       _mthis.DisplayHistoryMenu,  //show or hide message history menu
	            	pnotify_closer: 	   _mthis.ShowCloseButton,     //show or not close bottom
	            	pnotify_stack:         _stack,
	            	pnotify_addclass: 	   _notifyclass,
	            	pnotify_type: 		   type });
	            	
	            if (_mthis.MessageType == "bootstrap"){
	            	jQuery(notif[0].firstChild).removeClass();
	            	jQuery(notif[0].firstChild).find('.ui-icon-info').remove();
	            	if (type == 'error'){
	            		jQuery(notif[0].firstChild).find('.ui-icon-alert').remove();
	            	}
	           		jQuery(notif[0].firstChild).find('.ui-pnotify-text').removeClass('ui-pnotify-text');
	           	 	jQuery(notif[0].firstChild).addClass('alert')
	           	 	if (type == 'error'){
	           	 		jQuery(notif[0].firstChild).addClass('alert-danger')
	           	 	}
	            }	
	    });
	}
	
	this.renderNiftyModal = function(messages) {
		if ((messages == undefined) || (messages == null) || (messages == []) || (messages.length == 0))
			return; 
		
		var _mthis = this;
		
		var messagesContainer = messages
		if (messages.msgs) messagesContainer = messages.msgs
		
		jQuery.each(messagesContainer, function(index, value) {
				if (!value.text) return;
				
				var buffer = new gx.text.stringBuffer();
				var effect = _mthis.NiftyAnimationType
				
				var contentText = value.text.replace(/</g,"&lt;");
				var title = _mthis.NiftyDefaultMessageTitle;
				
				try{
					var initTitPos = value.text.indexOf(_mthis.NiftyMessageTitleTag);
					if (initTitPos != -1){
						var tempData = value.text.substring(_mthis.NiftyMessageTitleTag.length, value.text.length)
						var tempData = tempData.split(_mthis.NiftyMessageTitleTag)
						title = tempData[0].replace(/</g,"&lt;")
						contentText = tempData[1].replace(/</g,"&lt;")	
					}
				} catch (ERROR) {
					
				}
				
				buffer.clear();
				buffer.append('<div class="md-modal ' + effect + '" id="modal-'+_mthis.ContainerName+'">')
				buffer.append('<div class="md-content">')
					buffer.append('<h3 id="md-modal-title">' + title + '</h3>')
					buffer.append('<div>')
						buffer.append('<p id="md-modal-subtitle">'+ contentText +'</p>')
						if (_mthis.ShowCloseButton){
							buffer.append('<div align="center">')
							buffer.append('<a id="md-close-'+_mthis.ContainerName+'" class="md-close">' + _mthis.NiftyButtonText + '</a>')
							buffer.append('</div>')
						}
					buffer.append('</div>')
				buffer.append('</div>')
				buffer.append('</div>')
				buffer.append('<div class="md-overlay"></div>')
				_mthis.setHtml(buffer.toString()); 
		
		
		
				var modal = jQuery("#modal-"+_mthis.ContainerName)[0]
				var overlay = document.querySelector( '.md-overlay' );
		
			
				
				function removeModal( hasPerspective ) {
					classie.remove( modal, 'md-show' );	
					if( hasPerspective ) {
						classie.remove( document.documentElement, 'md-perspective' );
					}
				}
				function removeModalHandler() {
					removeModal(false);
				}
			
				setTimeout( function() {  
						classie.add( modal, 'md-show' );  
				} , 250);
			
				
				overlay.removeEventListener( 'click', removeModalHandler );
				overlay.addEventListener( 'click', removeModalHandler ); 
			
				if (_mthis.ShowCloseButton){
					var close = modal.querySelector( '.md-close' );
					close.addEventListener( 'click', function( ev ) {
						ev.stopPropagation();
						removeModalHandler();
					});
				}
				
				var HasEnter = false;
				try {
					if (!_mthis.ParentObject.IsMasterPage){
						if (_mthis.ParentObject.hasEnterEvent) HasEnter = true;
						_mthis.ParentObject.hasEnterEvent = false
					} else {
						if (gx.O.hasEnterEvent) HasEnter = true;
						gx.O.hasEnterEvent = false;
					}
				} catch (ERROR) {}
				$("body").keypress(function(e) {//capture event click enter 
   					 if ((e.which == 13) &&
   					 ($("#modal-"+_mthis.ContainerName)[0].getAttribute('class').indexOf("md-show") != -1)) { 
   				 		
   				 		
   				 		e.stopPropagation();
    		    		e.preventDefault();
   				 		removeModalHandler();
   				 		
    		    		if (HasEnter){
    		    			if (!_mthis.ParentObject.IsMasterPage){
								_mthis.ParentObject.hasEnterEvent = true;
							} else {
								gx.O.hasEnterEvent = true;
							}
						}
				  	}
				});
			
				if (_mthis.AutoClose){
					setTimeout( function() {  removeModalHandler(); } , 250 + _mthis.DelayUntilClose);
				}
	 });
        
		
	} 
	
	this.renderAlert = function(messages) {
		var messagesContainer = messages
		if (messages.msgs) messagesContainer = messages.msgs
        jQuery.each(messagesContainer, function(index, value) {
        	if (!value.text) return;
            alert(value.text.replace(/</g,"&lt;"));
        });
    }

    this.renderDialog = function(messages) {
        var _this = this;
        var _position = "";
		switch(this.StartPosition)
		{
			case "TopCenter":
  				_position = ['center', 'top'];
  				break;
			case "TopLeft":
  				_position = ['left', 'top'];
  				break;
  			case "TopRight":
  				_position = ['right', 'top'];
  				break;	
  			case "BottomRight":
  				_position = ['right', 'bottom'];
  				break;
  			case "BottomCenter":
  				_position = ['center', 'bottom'];
  				break;
  			case "BottomLeft":
  				_position = ['left', 'bottom'];
  				break;
  			case "DialogCenter":
  				_position = ['center', 'center'];
  				break;
		}
		var _show = "";
		if (this.AnimationType === "slide"){
			_show = "slide"
		} 
		
		var messagesContainer = messages
		if (messages.msgs) messagesContainer = messages.msgs
			
		jQuery.each(messagesContainer, function(index, value) {
			if (!value.text) return;
			
			var buffer = new gx.text.stringBuffer();
			buffer.clear();
			
			var contentText = value.text.replace(/</g,"&lt;");
			var title = _this.DialogDefaultMessageTitle;
			
			try{
				var initTitPos = value.text.indexOf(_this.DialogMessageTitleTag);
				if (initTitPos != -1){
					var tempData = value.text.substring(_this.DialogMessageTitleTag.length, value.text.length)
					var tempData = tempData.split(_this.DialogMessageTitleTag)
					title = tempData[0].replace(/</g,"&lt;")
					contentText = tempData[1].replace(/</g,"&lt;")	
				}
			} catch (ERROR) {
					
			}
			
			if (title.length > 38){
				buffer.append('<div id="' + _this.ControlName + '" title="' + title.substring(0,35) + '..."><p>' + contentText + '</p></div>');
			} else {
				buffer.append('<div id="' + _this.ControlName + '" title="' + title + '"><p>' + contentText + '</p></div>');
			}
			_this.setHtml(buffer.toString());
			jQuery('#' + _this.ControlName).dialog({	
							width: 260,
							height: 120,
							open: function(event, ui)
							{
									var textarea = jQuery('<p>' + contentText + '</p>');
									jQuery(this).html(textarea);
									if (!_this.ShowCloseButton){	
										jQuery(".ui-dialog-titlebar-close").hide();
									}
							},
							position: _position,
							show:     _show
			});
			if (_this.AutoClose){	setTimeout( function() {jQuery('#' + _this.ControlName).remove();},_this.DelayUntilClose)	}
		 });
				
	}

}