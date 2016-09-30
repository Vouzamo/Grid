/// <reference path="../_references.js" />

Vouzamo = (function(module) {

    // constructor
    module.Grid = function(host, path) {
        this.host = host;
        this.path = path;
        this.position = new THREE.Vector3(0, 0, 0);
    }
    
    // prototype
    module.Grid.prototype = (function(base) {
        var prototype = Object.create(base);
        
        prototype.constructor = module.Grid;
        
        // methods
        
        return prototype;
    }({}));

    return module;
}(Vouzamo || {}));