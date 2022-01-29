# HTWebRemote
#### Simple remote control of your home theater devices and HTPC from any web browser

HTWebRemote is an application meant to control various home theater devices and a home theater PC running Windows. Device control is mostly done via IP control and/or direct control of the Windows PC that HTWebRemote is  running on itself.

#### Web Page Builder

As a primary method of control, HTWebRemote helps you create simple web pages with buttons and then assign commands to the buttons to control your devices.  You then open these web pages on your phone or tablet to conveniently send the commands.

##### File Browser Interface

Included in the web page mode of operation is a simple file browser interface which lets you add folders from your HTPC and then browse them to easily select media to play on your HTPC.

##### YouTube Browser

Also included in the web page mode of operation is a YouTube browser and video launching feature.  You can copy and paste a YouTube link or browse YouTube by search phrase and easily send the YouTube video to play on your HTPC in a browser or even send the YouTube video to your media player such as MPC-HC/BE or VLC.

#### Screenshots and Demo

###### Main screen
<img src="https://user-images.githubusercontent.com/1866075/139782364-1e7586e9-9490-4439-9c67-0c823dbb182b.png" width="500px" />

###### Remote Editor
<img src="https://user-images.githubusercontent.com/1866075/139782414-25d768a2-dc89-4b72-99b6-c1d11ba1e5af.png" width="500px" />

###### Usage Demo
<img src="https://user-images.githubusercontent.com/1866075/80928497-78be2b00-8d6a-11ea-919a-03c93deb7be7.gif" width="222px" />

#### Command Line Mode

HTWebRemote also offers a command line mode of operation that lets you send commands to your devices by running HTWebRemote from the command line and passing in a few parameters to tell it which command to send to which device.

#### URL API Mode

Finally, HTWebRemote includes a sort of API which lets you send commands from other network devices simply by crafting a URL with a few query strings that again tell it which command to send to which device.

### Supported Devices

* Windows PC (open and close programs, etc)
* Keyboard Hotkeys (Control any program that supports hotkeys like most media players)
* [MPC-HC](https://github.com/clsid2/mpc-hc) and [MPC-BE](https://sourceforge.net/projects/mpcbe/)
* Zoom Player
* Nvidia Shield
* Roku
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
* Epson Projectors
* BenQ Projectors
* Christie M-Series / TruLife+ Projectors
* Oppo Disc Player
* D-BOX HEMC
* RS232 Serial Devices
* HTTP URL Commands (GET)
* MQTT Messaging Protocol

Support for more devices is subject to community requests and their ability to run tests for me as I try to add the support for their device.

I also welcome others to contribute additional device support here on GitHub if they are able to.

### Getting Started

No installation or prerequisites are necessary.

Simply download the [latest build from the releases](https://github.com/nicko88/HTWebRemote/releases/latest) page, extract the archive, and copy the files to your preferred folder location on your HTPC.

See the [documentation](https://raw.githack.com/nicko88/HTWebRemote/master/HTWebRemote/Util/html/doc.html) within the program for detailed operation instructions.

### Community

Visit the forum thread [here.](https://www.avsforum.com/threads/htwebremote-simple-remote-control-of-your-home-theater-devices-and-htpc-from-any-web-browser.3141648)
