float2 lightPositions[100];
float lightRadii[100];
float lightBrightness[100];
int numLights;

// From application to vertex shader
struct a2v
{ 
    float4 Position : POSITION;
    float4 Color    : COLOR0; 
};

// From vertex shader to pixel shader
struct v2p
{
    float4 Position : POSITION;
    float4 Color    : COLOR0;
};

// From pixel shader to screen
struct p2f
{
	float4 Color	: COLOR0;
};

// Vertex shader
void VS(in a2v IN, out v2p OUT)
{
	OUT.Position = IN.Position;
	OUT.Color = IN.Color;
}

// Pixel Shader
void PS(in v2p IN, out p2f OUT)
{
	float distanceToLight;
	float4 Colour = float4(0, 0, 0, 0.5);
	float lightRatio = 0.0;
	
	// Loop through all the lights in the level
	/*for (int i = 0; i < numLights; i+=1)
	{
		// Get the distance between the point and the light
		distanceToLight = distance(Pos, lightPositions[i]);
		
		if (distanceToLight < lightRadii[i])
		{
			lightRatio += distanceToLight/lightRadii[i];
		}
	}*/

	//OUT.Color = IN.Color;
	//OUT.Color[3] *= Colour[3];
	OUT.Color = Colour;
}

technique Shader
{
	pass P0
	{
		//VertexShader = compile vs_2_0 VS();
		PixelShader = compile ps_2_0 PS();
	}
}