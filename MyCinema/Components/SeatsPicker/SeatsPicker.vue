<template>
<div class="my-seats-picker">
    <div v-for="(rows, index) in seats"
        :key="index"
        :row-index="index"
        class="seats-picker-row">
        <div v-for="seat in rows"
            :key="seat.id"
            @click="onSeatClicked(seat)"
            class="seats-picker-seat"
            :class="{'is-active': seat.isActive}">
                {{seat.number}}
        </div>
    </div> 
</div>
</template>

<script>

export default {
    name: 'SeatsPicker',
    data: function() {
        return {
            seats: [
                [
                    {
                    number: 1,
                    id: 1001
                    }, 
                    {number: 2,
                    id: 1002 
                    },
                    {number: 3,
                    id: 1003 
                    },
                    {number: 4,
                    id: 1004 
                    }
                ],
                [   
                    {number: 1,
                    id: 2001
                    }, 
                    {number: 2,
                    id: 2002 
                    },
                    {number: 3,
                    id: 2003 
                    }
                ],
            ],
            choosenSeats: []
        }
    },
    methods: {
        onSeatClicked: function(value) {
            console.log(value)
            value.isActive = !value.isActive;

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
@import "Styles/Main";
@import "Styles/Variables";

.my-seats-picker {

    .seats-picker-row {
        display: flex;
        margin-bottom: 10px; 

        .seats-picker-seat:not(:first-of-type) {
            margin-left: 10px;
        }
    }
    
    .seats-picker-seat {
        background: $my-color-primary;
        color: $my-color-white;
        width: 30px;
        height: 30px;

        &.is-active {
            background: $my-color-black;
        }
    }
}

</style>