## [Download latest release](https://github.com/nicko88/HTWebRemote/releases/latest)

# HTWebRemote
#### Simple remote control of your home theater devices and HTPC from any web browser

HTWebRemote is an application meant to control various home theater devices and a home theater PC running Windows. Device control is mostly done via IP control and/or direct control of the Windows PC that HTWebRemote is running on itself.

#### See here for RaspberryPi / Linux version

[HTWebRemoteHost](https://github.com/nicko88/HTWebRemoteHost)

#### Web Page Builder

As a primary method of control, HTWebRemote helps you create simple web pages with buttons and then assign commands to the buttons to control your devices.  You then open these web pages on your phone or tablet to conveniently send the commands.

##### File Browser Interface

Included in the web page mode of operation is a simple file browser interface which lets you add folders from your HTPC and then browse them to easily select media to play on your HTPC.

##### YouTube Browser

Also included in the web page mode of operation is a YouTube browser and video launching feature.  You can copy and paste a YouTube link or browse YouTube by search phrase and easily send the YouTube video to play on your HTPC in a browser or even send the YouTube video to your media player such as MPC-HC/BE or VLC.

##### Voice Commands

The Voice Command manager allows you to define voice commands that when spoken, can trigger HTWebRemote commands.  This is a completely offline service and is very fast.  Voice commands are also only supported by HTWebRemote when running on Windows, and it uses the audio input device that is set to the default in Windows.

You can set a confidence value for each voice command that can help fine-tune the sensitivity to triggering. There is a "Test Mode" provided that can help you determine the optimal confidence value to set, by showing you what the confidence value is when you speak one of the commands phrases.

##### Global Hotkeys

The Global Hotkeys manager allows you to define global hotkeys, that when pressed in Windows, can trigger HTWebRemote commands. Global meaning the hotkey will be triggered no matter what application is running or has keyboard focus.

This feature works well with a [FLIRC USB IR reciever](https://flirc.tv/products/flirc-usb-receiver). Using a FLIRC allows you to use any random button on any random IR remote control to generate hotkey presses in Windows, and thus trigger any HTWebRemote commands.

##### Mobile "WebApp" Mode

Consider adding your remote control page to the home screen of your phone or tablet.  This will give you more vertical space to see your remote control buttons and also give you a nice App icon to quickly access your remote control.

If you don't know how to do this, just do a web search for how to add a web page to your home screen for either iPhone or Android.

##### Siri and Apple Widgets Integration

To learn how to create Siri voice commands to send any HTWebRemote command or macro (on iPhone/iPad/AppleWatch/HomePod), or to create native homescreen Widget buttons (on iPhone/iPad/AppleWatch), see this [wiki page](https://github.com/nicko88/HTWebRemote/wiki/Control-HTWebRemote-on-iOS-Devices-Including-Apple-Watch-and-HomePod).

#### Screenshots and Demo

###### Main screen
<img src="https://github.com/nicko88/HTWebRemote/assets/1866075/d6b770f2-2ed0-4bfb-ae51-bc690ccebcba" width="592px" />

###### Remote Editor
<img src="https://github.com/nicko88/HTWebRemote/assets/1866075/ecb4e988-8c1c-4163-954b-dc317820aa28" width="px" />

###### Usage Demo
<img src="https://user-images.githubusercontent.com/1866075/182762525-38084139-6bc9-4414-a932-5d5febcc1baa.gif" width="222px" />

#### Command Line Mode

HTWebRemote also offers a command line mode of operation that lets you send commands to your devices by running HTWebRemote from the command line and passing in a few parameters to tell it which command to send to which device.

#### URL API Mode

Finally, HTWebRemote includes a sort of API which lets you send commands from other network devices simply by crafting a URL with a few query strings that again tell it which command to send to which device.

### Directly Supported Devices

* Windows / Linux (open and close programs, run scripts, etc)
* Keyboard Hotkeys (Control any program that supports hotkeys like most media players)
* [MPC-HC](https://github.com/clsid2/mpc-hc) and [MPC-BE](https://sourceforge.net/projects/mpcbe/)
* Kodi Media Player
* Zoom Player
* Nvidia Shield
* Roku
* Zappiti Media Player Box
* [WinLIRC](http://winlirc.sourceforge.net/) and [LIRC](https://www.lirc.org/)
* Belkin Wemo Smart Plug
* TP-Link Kasa Smart Devices
* Philips Hue Bridge
* Denon / Marantz AVRs
* Yamaha AVRs
* Emotiva AVRs
* StormAudio ISP AVRs
* Monoprice HTP-1 AVR
* Anthem MRX AVRs
* Lyngdorf AVRs
* Trinnov Altitude AVRs
* Onkyo/Integra/Pioneer AVRs (eISCP)
* JVC Projectors
* Sony Projectors
* Epson Projectors
* BenQ Projectors
* Christie M-Series / TruLife+ Projectors
* Panasonic Projectors
* LG webOS TVs/Projectors
* Samsung TizenOS TVs/Projectors
* Oppo Disc Player
* D-BOX HEMC
* HDFury Devices
* MiniDSP Devices (via [minidsp-rs](https://github.com/mrene/minidsp-rs))
* RS232 Serial Devices
* TCP/UDP Generic Devices
* HTTP POST/GET/PUT Requests
* MQTT Messaging Protocol
* Wake-on-LAN

### Unofficially Supported Devices (Tested Working by the Community)

HTWebRemote can support controlling a lot of other devices through generic control methods such as generic TCP/UDP sockets and HTTP REST APIs.  
The following page is a list of devices that users have successfully controlled with HTWebRemote.

[Other Device Support](https://github.com/nicko88/HTWebRemote/wiki/Other-Device-Support)

Support for more devices is subject to community requests and their ability to run tests for me as I try to add the support for their device.

I also welcome others to contribute additional device support here on GitHub if they are able to.

### Getting Started

No installation or prerequisites are necessary.

Simply download the [latest build from the releases](https://github.com/nicko88/HTWebRemote/releases/latest) page, extract the archive, and copy the files to your preferred folder location on your HTPC.

See the [documentation](https://htmlpreview.github.io/?https://github.com/nicko88/HTWebRemote/blob/master/HTWebRemote/Util/html/doc.html) within the program for detailed operation instructions.

### Hosting Remotes from a RaspberryPi / Linux PC

There is a companion app called [HTWebRemoteHost](https://github.com/nicko88/HTWebRemoteHost) which lets you host your remote controls on a RasPi or typical Linux PC/server.  The reason someone might want to do this is if they don't have a Windows PC that is just always powered on that they can host their remotes from.

HTWebRemoteHost is a headless service, and you must use this Windows app to create and modify your remote controls, and then "Sync" them to the HTWebRemoteHost service on your RasPi / Linux PC.

Keep in mind that the *"keys"* device control will **not** be operational on a RasPi / Linux Host.

### Community

Visit the forum thread [here.](https://www.avsforum.com/threads/htwebremote-simple-remote-control-of-your-home-theater-devices-and-htpc-from-any-web-browser.3141648)