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

##### Mobile "WebApp" Mode

Consider adding your remote control page to the home screen of your phone or tablet.  This will give you more vertical space to see your remote control buttons and also give you a nice App icon to quickly access your remote control.

If you don't know how to do this, just do a web search for how to add a web page to your home screen for either iPhone or Android.

#### Screenshots and Demo

###### Main screen
<img src="https://user-images.githubusercontent.com/1866075/216807486-3056bcf7-a40d-4a41-9a9d-18c10a3f6f4c.png" width="600px" />

###### Remote Editor
<img src="https://user-images.githubusercontent.com/1866075/216807485-4fbe9984-c93c-41f7-b12a-c53854bb1dd6.png" width="600px" />

###### Usage Demo
<img src="https://user-images.githubusercontent.com/1866075/182762525-38084139-6bc9-4414-a932-5d5febcc1baa.gif" width="222px" />

#### Command Line Mode

HTWebRemote also offers a command line mode of operation that lets you send commands to your devices by running HTWebRemote from the command line and passing in a few parameters to tell it which command to send to which device.

#### URL API Mode

Finally, HTWebRemote includes a sort of API which lets you send commands from other network devices simply by crafting a URL with a few query strings that again tell it which command to send to which device.

### Supported Devices

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
* Denon / Marantz AVRs
* Yamaha AVRs
* Emotiva AVRs
* StormAudio ISP AVRs
* Monoprice HTP-1 AVR
* Anthem MRX AVRs
* Lyngdorf AVRs
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
* TCP Generic Devices
* UDP Generic Devices
* HTTP POST Requests
* HTTP GET Requests
* MQTT Messaging Protocol
* Wake-on-LAN

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