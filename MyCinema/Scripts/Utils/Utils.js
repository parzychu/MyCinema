
export default {
    toggleIsActiveProp: function (current, previous) {
        previous && (previous.isActive = false);
        current.isActive = !current.isActive;
        previous = current;
      }
}