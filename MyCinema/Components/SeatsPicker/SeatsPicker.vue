
<template>
<div class="my-seats-picker">
    <div class="seats-picker-cinema-room">
    <div v-for="(rows, index) in seats"
        :key="index"
        :row-index="index"
        class="seats-picker-row">
        <div v-for="seat in rows"
            :key="seat.id"
            @click="onSeatClicked(seat)"
            class="seats-picker-seat"
            :class="{'is-active': seat.isActive}">
                <span>{{seat.col}}</span>
        </div>
    </div> 
    </div>
</div>
</template>

<script>
export default {
    name: 'SeatsPicker',
    data: function() {
        return {
            choosenSeats: []
        }
    },
    props: ['seats'],
    methods: {
        onSeatClicked: function(value) {
            this.$set(value, 'isActive', !value.isActive)
            if (value.isActive) {
                this.choosenSeats.push(value.id);
            } else {
                let index = this.choosenSeats.indexOf(value.id)
                this.choosenSeats.splice(index, 1);
            }

            this.$emit('changed', this.choosenSeats);
        }
    }
}
</script>

<style lang="scss">
@import "Styles/Variables";

.my-seats-picker {
    .seats-picker-cinema-room {
        display: flex;
        flex-direction: column;
        align-items: center;
    }

    .seats-picker-row {
        display: flex;
        margin-bottom: 10px; 

        .seats-picker-seat:not(:first-of-type) {
            margin-left: 10px;
        }
    }
    
    .seats-picker-seat {
        color: $my-color-gray-icon-active;
        width: 50px;
        height: 35px;
        border-bottom-left-radius: 8px;
        border-bottom-right-radius: 8px;
        display: flex;
        align-items: center;
        justify-content: center;
        text-align: center;
        border: 1px solid $my-color-primary;

        &.is-active {
            background: $my-color-primary;
            color: $my-color-white;
        }

        &.is-hidden {
            visibility: hidden;
        }

        &.is-taken {
            background-image: repeating-linear-gradient(-45deg, transparent, transparent 4px, $my-color-primary 4px,$my-color-primary 8px);
        }
    }
}

</style>