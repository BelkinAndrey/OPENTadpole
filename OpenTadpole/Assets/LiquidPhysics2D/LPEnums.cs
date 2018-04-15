public enum LPBodyTypes
{
	Static = 0
	,Dynamic = 1
	,Kinematic = 2
};

public enum LPRayCastHitType
{
	 LPFixture = 0
	,LPParticle = 1
};

public enum LPShapeTypes
{
	 Box = 0
	,Polygon = 0
	,Circle = 1
	,Edge = 2
	,ChainShape = 3
};

public enum LPRaycastModes
{
	HitAnything = 0
	,HitEverything = 1
	,FindNearest = 2
};

public enum  b2ParticleFlag
{
	b2_waterParticle = 0, b2_zombieParticle = 1 << 1, b2_wallParticle = 1 << 2, b2_springParticle = 1 << 3,
	b2_elasticParticle = 1 << 4, b2_viscousParticle = 1 << 5, b2_powderParticle = 1 << 6, b2_tensileParticle = 1 << 7,
	b2_colorMixingParticle = 1 << 8, b2_destructionListenerParticle = 1 << 9, b2_barrierParticle = 1 << 10, b2_staticPressureParticle = 1 << 11,
	b2_reactiveParticle = 1 << 12, b2_repulsiveParticle = 1 << 13, b2_fixtureContactListenerParticle = 1 << 14, b2_particleContactListenerParticle = 1 << 15,
	b2_fixtureContactFilterParticle = 1 << 16, b2_particleContactFilterParticle = 1 << 17
};

enum  	b2ParticleGroupFlag {
	b2_solidParticleGroup = 1 << 0, b2_rigidParticleGroup = 1 << 1, b2_particleGroupCanBeEmpty = 1 << 2, b2_particleGroupWillBeDestroyed = 1 << 3,
	b2_particleGroupNeedsUpdateDepth = 1 << 4, b2_particleGroupInternalMask
}