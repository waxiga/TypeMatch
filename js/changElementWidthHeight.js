function changWidthHeight(elementID,final_width,final_height,interval) {
  if (!document.getElementById) return false;
  if (!document.getElementById(elementID)) return false;
  var elem = document.getElementById(elementID);
  if (elem.movement) {
    clearTimeout(elem.movement);
  }
  if (!elem.style.width) {
    elem.style.width = "0px";
  }
  if (!elem.style.height) {
    elem.style.height = "0px";
  }
  var xpos = parseInt(elem.style.width);
  var ypos = parseInt(elem.style.height);
  if (xpos == final_width && ypos == final_height) {
    return true;
  }
  if (xpos < final_width) {
    var dist = Math.ceil((final_width - xpos)/5);
    xpos = xpos + dist;
  }
  if (xpos > final_width) {
    var dist = Math.ceil((xpos - final_width)/5);
    xpos = xpos - dist;
  }
  if (ypos < final_height) {
    var dist = Math.ceil((final_height - ypos)/5);
    ypos = ypos + dist;
  }
  if (ypos > final_height) {
    var dist = Math.ceil((ypos - final_height)/5);
    ypos = ypos - dist;
  }
  elem.style.width = xpos + "px";
  elem.style.height = ypos + "px";
  var repeat = "changWidthHeight('"+elementID+"',"+final_width+","+final_height+","+interval+")";
  elem.movement = setTimeout(repeat,interval);
}