import * as THREE from 'https://cdn.jsdelivr.net/npm/three@0.180.0/build/three.module.js';
import { PointerLockControls } from 'https://cdn.jsdelivr.net/npm/three@0.180.0/examples/jsm/controls/PointerLockControls.js';

const menu=document.querySelector('#menu'),hud=document.querySelector('#hud'),cross=document.querySelector('#crosshair');
const nameInput=document.querySelector('#name'),play=document.querySelector('#play'),playerName=document.querySelector('#playerName'),speedText=document.querySelector('#speed');
let scene,camera,renderer,controls,car,player,driving=false,velocity=0,heading=0;
const keys={};

function mat(c){return new THREE.MeshStandardMaterial({color:c,roughness:.9});}
function box(w,h,d,c){const m=new THREE.Mesh(new THREE.BoxGeometry(w,h,d),mat(c));return m;}

function init(){
 scene=new THREE.Scene(); scene.background=new THREE.Color(0x87b6d8); scene.fog=new THREE.Fog(0x87b6d8,80,420);
 camera=new THREE.PerspectiveCamera(72,innerWidth/innerHeight,.05,700); camera.position.set(0,1.7,5);
 renderer=new THREE.WebGLRenderer({antialias:true}); renderer.setPixelRatio(Math.min(devicePixelRatio,2)); renderer.setSize(innerWidth,innerHeight); renderer.shadowMap.enabled=true; document.body.appendChild(renderer.domElement);
 scene.add(new THREE.HemisphereLight(0xffe2b3,0x66513f,2.1)); const sun=new THREE.DirectionalLight(0xffd18a,2.4); sun.position.set(-80,120,40); sun.castShadow=true; scene.add(sun);
 makeDesert(); makeCar(); makePlayer();
 controls=new PointerLockControls(camera,document.body);
 controls.addEventListener('lock',()=>{}); controls.addEventListener('unlock',()=>{if(driving) driving=false;});
 addEvents(); animate();
}
function makeDesert(){
 const ground=box(520,.4,520,0xc99b5e); ground.position.y=-.2; ground.receiveShadow=true; scene.add(ground);
 const road=box(22,.08,520,0x252525); road.position.y=.02; scene.add(road);
 for(let z=-240;z<240;z+=12){const line=box(.35,.09,6,0xe9dfbd);line.position.set(0,.09,z);scene.add(line)}
 for(let i=0;i<90;i++){const x=(Math.random()-.5)*240;const z=(Math.random()-.5)*480;if(Math.abs(x)<18)continue;const rock=box(1+Math.random()*5,1+Math.random()*3,1+Math.random()*5,0x8b633e);rock.position.set(x,.5,z);rock.rotation.y=Math.random()*Math.PI;scene.add(rock)}
 for(let z=-220;z<220;z+=55){const sign=box(2.2,2.5,.15,0x5b3b26);sign.position.set(15,1.25,z);scene.add(sign)}
}
function makeCar(){
 car=new THREE.Group(); car.position.set(0,.7,0); scene.add(car);
 const body=box(3,0.75,5.4,0xb33e2e);body.position.y=.65;body.castShadow=true;car.add(body);
 const cabin=box(2.55,.95,2.5,0x20252b);cabin.position.set(0,1.35,-.15);car.add(cabin);
 const hood=box(2.7,.25,1.4,0xb33e2e);hood.position.set(0,1.02,1.55);car.add(hood);
 for(const x of [-1.55,1.55])for(const z of [-1.65,1.65]){const w=new THREE.Mesh(new THREE.CylinderGeometry(.45,.45,.3,20),mat(0x171717));w.rotation.z=Math.PI/2;w.position.set(x,.35,z);car.add(w)}
 const seat=box(1.1,.5,1.1,0x3b3030);seat.position.set(0,1.0,.2);car.add(seat);
}
function makePlayer(){player=new THREE.Group();const body=box(.65,1.2,.4,0x4775b8);body.position.y=1.0;player.add(body);const head=new THREE.Mesh(new THREE.SphereGeometry(.27,16,12),mat(0xd89a72));head.position.y=1.8;player.add(head);player.position.set(4,0,5);scene.add(player)}
function addEvents(){
 play.onclick=()=>{playerName.textContent=nameInput.value.trim()||'Driver';menu.classList.add('hidden');hud.classList.remove('hidden');cross.classList.remove('hidden');controls.lock()};
 addEventListener('keydown',e=>{keys[e.key.toLowerCase()]=true;if(e.key.toLowerCase()==='e')toggleCar();if(e.key==='Escape'){menu.classList.remove('hidden');hud.classList.add('hidden');cross.classList.add('hidden');controls.unlock()}});
 addEventListener('keyup',e=>keys[e.key.toLowerCase()]=false);
 addEventListener('resize',()=>{camera.aspect=innerWidth/innerHeight;camera.updateProjectionMatrix();renderer.setSize(innerWidth,innerHeight)});
}
function nearCar(){return camera.position.distanceTo(car.position)<7}
function toggleCar(){if(!driving&&nearCar()){driving=true;camera.position.copy(car.position).add(new THREE.Vector3(0,1.35,.45));velocity=0}else if(driving){driving=false;camera.position.copy(car.position).add(new THREE.Vector3(4,1.7,3));}}
function update(dt){
 if(driving){let accel=0;if(keys.w||keys.arrowup)accel=18;if(keys.s||keys.arrowdown)accel=-14;velocity+=accel*dt;velocity*=Math.pow(.18,dt);velocity=THREE.MathUtils.clamp(velocity,-12,38);if(keys.a||keys.arrowleft)heading+=2.1*dt*(Math.abs(velocity)/20+.15);if(keys.d||keys.arrowright)heading-=2.1*dt*(Math.abs(velocity)/20+.15);car.rotation.y=heading;car.translateZ(-velocity*dt);camera.position.copy(car.position);camera.position.y+=1.35;camera.position.z+=.35;camera.rotation.set(0,car.rotation.y,0,'YXZ');speedText.textContent=Math.round(Math.abs(velocity)*3.6)+' km/h';}
 else {let move=new THREE.Vector3();if(keys.w)move.z-=1;if(keys.s)move.z+=1;if(keys.a)move.x-=1;if(keys.d)move.x+=1;if(move.lengthSq()){move.normalize().multiplyScalar(dt*5);move.applyQuaternion(new THREE.Quaternion().setFromEuler(new THREE.Euler(0,camera.rotation.y,0)));player.position.add(move);camera.position.copy(player.position);camera.position.y=1.7;speedText.textContent='Walking'} }
}
let last=performance.now();function animate(){requestAnimationFrame(animate);const now=performance.now(),dt=Math.min((now-last)/1000,.05);last=now;update(dt);renderer.render(scene,camera)}
init();
