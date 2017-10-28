<template>
<div class="my-seats-picker-seat"
    :class="{'is-active': isActive}"
    v-on:click="onClicked">
    <div>{{data.number}}</div>
</div>
</template>

<script>


export default {
    name: 'SeatsPickerSeat',
    props: ['data'],
    data: function() {
        return {
            isActive:false
        }
    },
    methods: {
        onClicked: function () {
            console.log('onClicked')
            this.isActive = !this.isActive;
            
            this.$emit('changed', {isActive: this.isActive, id: this.data.id})
        }
    }
}
</script>

<style lang="scss">
@import "Styles/Main";
@import "Styles/Variables";

    .my-seats-picker-seat {
        background: $my-color-primary;
        color: $my-color-white;
        width: 30px;
        height: 30px;

        &.is-active {
            background: $my-color-black;
        }
    }
</style>