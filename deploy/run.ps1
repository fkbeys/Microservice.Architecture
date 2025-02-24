﻿param (
	[Int32][ValidateRange(1, 10)] $nodes = 1,
	[Int32][ValidateRange(2, 10)] $cpus = 2,
	[Int32][ValidateRange(2048, 8192)] $memory = 2048,
	[string] $registry = '',
	[string] $tag = '',
	[switch] $build = $false
)

.\_start.ps1 -nodes $nodes -cpus $cpus -memory $memory -registry $registry

If (![string]::IsNullOrEmpty($registry) -And !$registry.EndsWith('/'))
{
	$registry += '/'
}

If ($build)
{
	.\_build.ps1 -registry $registry -tag $tag
}
.\_deploy.ps1 -registry $registry -tag $tag
.\_expose.ps1