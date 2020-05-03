# HTPCRemote
#### Simple remote control of your home theater from any web browser.

HTPCRemote is an application meant to control various home theater devices and a home theater PC running Windows. Device control is mostly done via IP control and/or direct control of the Windows PC that HTPCRemote is  running on itself.

#### Web Page Builder

As a primary method of control, HTPCRemote helps you create simple web pages with buttons and then assign commands to the buttons to control your devices.  You then open these web pages on your phone or tablet to conveniently send the commands.

##### File Browser Interface

Included in the web page mode of operation is a simple file browser interface which lets you add folders from your HTPC and then browse them to easily select media to play on your HTPC.

#### Screenshots and Demo
<img src="https://user-images.githubusercontent.com/1866075/80928490-6217d400-8d6a-11ea-9d13-19f90fbe70ee.png" width="500px" style="padding-bottom: 25px;"/>
<br/>
<img src="https://user-images.githubusercontent.com/1866075/80928492-6fcd5980-8d6a-11ea-86aa-8f5d3bb3e619.png" width="500px" style="padding-right: 50px;" />
<img src="https://user-images.githubusercontent.com/1866075/80928497-78be2b00-8d6a-11ea-919a-03c93deb7be7.gif" width="222px" style="position: absolute; margin-top: -100px;" />

#### Command Line Mode

HTPCRemote also offers a command line mode of operation that lets you send commands to your devices by running HTPCRemote from the command line and passing in a few parameters to tell it which command to send to which device.

#### URL API Mode

Finally, HTPCRemote includes a sort of API which lets you send commands from other network devices simply by crafting a URL with a few query strings that again tell it which command to send to which device.

### Supported Devices

* Windows PC
* Keyboard Hotkeys
* [MPC-HC](https://github.com/clsid2/mpc-hc) and [MPC-BE](https://sourceforge.net/projects/mpcbe/)
* [WinLIRC](http://winlirc.sourceforge.net/) and [LIRC](https://www.lirc.org/)
* Belkin Wemo Smart Plug
* Denon / Marantz AVRs
* JVC Projectors
* BenQ Projectors
* Emotiva AVRs
* D-BOX HEMC

Support for more devices is subject to community requests and their ability to run tests for me as I try to add the support for their device.

I also welcome others to contribute additional device support here on GitHub if they are able to.

### Getting Started

No installation or prerequisites are necessary.

Simply download the latest build from the releases page, extract the archive, and copy the files to your preferred folder location on your HTPC.

See the [documentation](https://raw.githack.com/nicko88/HTPCRemote/master/HTPCRemote/Util/html/doc.html) within the program for detailed operation instructions.