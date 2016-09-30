Vouzamo.Models = (function(module) {
    
    // constructor
    module.Item = function(name, position) {
        this.name = name;
        this.position = position;
    }
    
    // prototype
    module.Item.prototype = (function(base) {
        var prototype = Object.create(base);
        
        prototype.constructor = module.Item;
        
        // methods
        prototype.serialize = function() {
            return this.name + ", [" + this.position.x + ',' + this.position.y + ',' + this.position.z + ']';
        }

        prototype.alert = function() {
            alert('Item');
        }
        
        return prototype;
    }({}));
    
    return module;
}(Vouzamo.Models || {}));