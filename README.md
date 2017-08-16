# manage-computer-sound
Increase, decrease or mute system sound. If you are unable to control your speakers this can solve your problem!
  
## Installation
  1. Clone the project.
  2. `npm install` - to install all dependencies
  3. `node app` - to run the service

## How to use
After running the service it is accessible on:

`http://localhost:1886/controller/` - web page with sound controls

`http://localhost:1886/control/{task}` - direct access to sound settings
```
task must be:
    0 - to mute sound
    1 - volume down
    2 - volume up
```

## Dependencies
  1. [Edge][link-edge]
  2. [Express][link-express]

## License
The MIT License (MIT). Please see [License File](LICENSE) for more information.

[link-edge]: https://www.npmjs.com/package/edge
[link-express]: https://www.npmjs.com/package/express
