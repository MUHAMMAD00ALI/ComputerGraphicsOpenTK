﻿#version 330 core
layout (location = 0) in vec3 aPosition;
layout (location = 1) in vec3 aColor; // the color variable has attribute position 1
uniform mat4 model;
out vec3 ourColor; // output a color to the fragment shader
void main()
{
    gl_Position =  model *  vec4(aPosition, 1.0f) ;
    ourColor = aColor; // set ourColor to the input color we got from the vertex data
}