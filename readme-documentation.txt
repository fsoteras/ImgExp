Documentation

This is a command-line application for picture processing.
It provides functionality for expanding pictures by calling 

ImgExpnd  -ResizeByPercentage <number>  <path>

To double the size of an image use:

ImgExpnd -DoubleSize 

keying ImgExpnd without parameters will expose help data.

------------------------------------------

version history:

  // version alpha 0.9.3 , first rough version , testing how to call ImageProcessor lib.
    // This code assume to-be-processed pics to be found on  /pictures folder.

    // version alpha 0.9.4 , implementation of Command pattern , all new functionality
    // will be implemented with classes implementing ICommand interface.

    //  version alpha 0.9.5 , first releaseable version.

	// verison o.1.0 , released to github.

------------------------------------------
Sample test data
-DoubleSize C:\Users\fsoteras_admin\Pictures\pampa.png
