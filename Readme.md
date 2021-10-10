# HTPCRemote
#### Simple remote control of your HTPC and home theater devices from any web browser

HTPCRemote is an application meant to control various home theater devices and a home theater PC running Windows. Device control is mostly done via IP control and/or direct control of the Windows PC that HTPCRemote is  running on itself.

#### Web Page Builder

As a primary method of control, HTPCRemote helps you create simple web pages with buttons and then assign commands to the buttons to control your devices.  You then open these web pages on your phone or tablet to conveniently send the commands.

##### File Browser Interface

Included in the web page mode of operation is a simple file browser interface which lets you add folders from your HTPC and then browse them to easily select media to play on your HTPC.

##### YouTube Browser

Also included in the web page mode of operation is a YouTube browser and video launching feature.  You can copy and paste a YouTube link or browse YouTube by search phrase and easily send the YouTube video to play on your HTPC in a browser or even send the YouTube video to your media player such as MPC-HC/BE or VLC.

#### Screenshots and Demo

###### Main screen
<img src="https://user-images.githubusercontent.com/1866075/91256551-3f506780-e72d-11ea-9350-30a1aa8fa501.png" width="500px" />

###### Remote Editor
<img src="https://user-images.githubusercontent.com/1866075/91256588-52fbce00-e72d-11ea-8ae3-4b4ae95bb1fc.png" width="500px" />

###### Usage Demo
<img src="https://user-images.githubusercontent.com/1866075/80928497-78be2b00-8d6a-11ea-919a-03c93deb7be7.gif" width="222px" />

#### Command Line Mode

HTPCRemote also offers a command line mode of operation that lets you send commands to your devices by running HTPCRemote from the command line and passing in a few parameters to tell it which command to send to which device.

#### URL API Mode

Finally, HTPCRemote includes a sort of API which lets you send commands from other network devices simply by crafting a URL with a few query strings that again tell it which command to send to which device.

### Supported Devices

* Windows PC (open and close programs, etc)
* Keyboard Hotkeys (Control any program that supports hotkeys like most media players)
* [MPC-HC](https://github.com/clsid2/mpc-hc) and [MPC-BE](https://sourceforge.net/projects/mpcbe/)
* Zappiti Media Player Box
* [WinLIRC](http://winlirc.sourceforge.net/) and [LIRC](https://www.lirc.org/)
* Belkin Wemo Smart Plug
* Denon / Marantz AVRs
* Yamaha AVRs
* Emotiva AVRs
* StormAudio ISP AVRs
* Monoprice HTP-1 AVR
* Anthem MRX AVRs
* JVC Projectors
* BenQ Projectors
* Christie M-Series Projectors
* Oppo Disc Player
* D-BOX HEMC
* RS232 Serial Devices
* HTTP URL Commands (GET)
* MQTT Messaging Protocol

Support for more devices is subject to community requests and their ability to run tests for me as I try to add the support for their device.

I also welcome others to contribute additional device support here on GitHub if they are able to.

### Getting Started

No installation or prerequisites are necessary.

Simply download the [latest build from the releases](https://github.com/nicko88/HTPCRemote/releases/latest) page, extract the archive, and copy the files to your preferred folder location on your HTPC.

See the [documentation](https://raw.githack.com/nicko88/HTPCRemote/master/HTPCRemote/Util/html/doc.html) within the program for detailed operation instructions.

### Community

Visit the forum thread [here.](https://www.avsforum.com/forum/26-home-theater-computers/3141648-htpcremote-simple-remote-control-your-htpc-home-theater-any-web-browser.html)
