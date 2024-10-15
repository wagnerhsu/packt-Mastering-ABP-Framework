abp.modals.MovieCreation = function () {
     this.initModal = function(modalManager, args) {
        var $modal = modalManager.getModal();
        var preOrderCheckbox = $modal.find('input[name="Movie.PreOrder"]');
        preOrderCheckbox.change(function(){
            if (this.checked){
               alert('checked pre-order!'); 
            }
            $('#CheckTest').trigger('click');
        });
        console.log('initialized the modal...');
    }
};