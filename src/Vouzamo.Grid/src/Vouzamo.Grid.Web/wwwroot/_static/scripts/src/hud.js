Vouzamo.Models = (function(module) {
    
    // constructor
    module.Hud = function(name, position) {
        Vouzamo.Models.Item.call(this, name, position);
    }
    
    // prototype
    module.Hud.prototype = (function(base) {
        var prototype = Object.create(base);
        
        prototype.constructor = module.Hud;
        
        // methods
        prototype.isHud = function() {
            return true;
        }

        prototype.alert = function() {
            alert('Hud');
            base.alert();
        }
        
        return prototype;
    }(Vouzamo.Models.Item.prototype));
    
    return module;
}(Vouzamo.Models || {}));