<template>
  <div>
    <div class="topBar">
      <span class="topBarTitle">My landry shop</span>
      <b-button @click="toggle =! toggle" class="taskButton" size="is-small">
        <span v-if="!toggle">Show Tasks</span>
        <span v-else>Hide Tasks List ({{ tasks.filter(x=>x.done).length }} of {{tasks.length}})</span>
      </b-button>
    </div>
    <h3>Tasks:</h3>
      <button @click="addTask">Add Laundry Task</button>
      <div v-if="toggle" class="taskView">
        <div :key="r.id" v-for="r in tasks">
          <div class="columns">
            <div class="column">
              <span>{{ r.desc }} </span>
            </div>
            <div class="column">
              <font-awesome-icon icon="spinner" :spin="!r.done" v-if="!r.done" />
              <font-awesome-icon style="color:green" icon="check" v-if="r.done" />
            </div>
          </div>
        </div>
      </div>
    <br />
    <br />
  </div>
</template>

<script>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { faSpinner,fas } from '@fortawesome/free-solid-svg-icons'
import { HubConnectionBuilder } from '@microsoft/signalr'

const connection = new HubConnectionBuilder().withUrl("http://localhost:5000/notify").build()
connection.start()

export default {
  name: 'TaskBar',
  data() {
    return {
      tasks:[],
      currentIds:1,
      toggle:false,
      spinner:faSpinner,
    }
  },
  mounted() {

  },
  methods: {
    addTask: function() {

    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}

.taskView {
  overflow-y:auto;overflow-x:hidden;max-height:400px;border-radius:0px 0px 0px 10px;background-color:lightblue;width:335px;position:absolute;right:0;top:1.8rem;border-left:1px solid #000;border-bottom:1px solid #000;
}

.topBar {
  text-align:left;position:absolute;top:0;width:100vw;background-color:#e3e3e3;height:1.7rem;box-shadow:#d3d3d3 1px 1px 1px 1px;
}

.topBarTitle {
  margin-left:1rem;font-weight:bold;
}

.taskButton {
  float:right;margin-right:0.5rem;
}
</style>
