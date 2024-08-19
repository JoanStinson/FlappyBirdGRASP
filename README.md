# Flappy Bird GRASP
A Flappy Bird clone game made with Unity applying GRASP.

<p align="center">
  <a>
    <img alt="Made With Unity" src="https://img.shields.io/badge/made%20with-Unity-57b9d3.svg?logo=Unity">
  </a>
  <a>
    <img alt="License" src="https://img.shields.io/github/license/JoanStinson/FlappyBirdGRASP?logo=github">
  </a>
  <a>
    <img alt="Last Commit" src="https://img.shields.io/github/last-commit/JoanStinson/FlappyBirdGRASP?logo=Mapbox&color=orange">
  </a>
  <a>
    <img alt="Repo Size" src="https://img.shields.io/github/repo-size/JoanStinson/FlappyBirdGRASP?logo=VirtualBox">
  </a>
  <a>
    <img alt="Downloads" src="https://img.shields.io/github/downloads/JoanStinson/FlappyBirdGRASP/total?color=brightgreen">
  </a>
  <a>
    <img alt="Last Release" src="https://img.shields.io/github/v/release/JoanStinson/FlappyBirdGRASP?include_prereleases&logo=Dropbox&color=yellow">
  </a>
</p>

<p align="center">
  <img src="https://github.com/JoanStinson/FlappyBirdGRASP/blob/main/preview.gif">
</p>

## 📜 Kata Rules
* A controllable bird that flaps upward with input and is affected by gravity.
* Single input control for making the bird flap (e.g., mouse click, tap).
* A repeating background to create the illusion of movement.
* Moving vertical pipes with gaps that the bird must pass through.
* A score system that increases when the bird passes through pipe gaps.
* Bird collisions with pipes or the ground should result in a game over.
* A game over screen with the option to restart.

## 🗺️ GRASP
> General Responsibility Assignment Software Principles
* **👨‍💻 Information Expert**
    * Assign responsibility to the class that has the necessary information to fulfill it. This ensures that operations are performed by the objects that have the data needed.
* **🎨 Creator**
    * Assign responsibility for creating an instance of a class to the class that has the necessary information to instantiate it, or that closely uses the created object.
* **🕹️ Controller**
    * Assign responsibility for handling system events to a class that represents a use case or overall system behavior. The controller coordinates the activities triggered by the event.
* **💔 Low Coupling**
    * Assign responsibilities to ensure that classes have minimal dependencies on each other. This reduces the impact of changes and increases reusability.
* **📚 High Cohesion**
    * Assign responsibilities to ensure that classes and modules have a single, well-defined purpose. This increases clarity and maintains focus within a class or module.
* **🐤 Polymorphism**
    * Assign responsibility for behavior, based on the type, to classes that inherit from a common superclass or implement a common interface. This allows different classes to be treated through a common interface.
* **🏭 Pure Fabrication**
    * Assign responsibilities to a class that is not a part of the problem domain but is created to achieve low coupling, high cohesion, or other design goals. This class does not represent a concept from the real-world problem space.
* **🚏 Indirection**
    * Assign responsibilities to intermediary objects to reduce the direct coupling between classes. This introduces an intermediary to control interactions, promoting flexibility.
* **🛡️ Protected Variations**
    * Assign responsibilities to create a stable interface that protects the system from variations or changes in other parts. This shields parts of the system from changes, making it more maintainable.
