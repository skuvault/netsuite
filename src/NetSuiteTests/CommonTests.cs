﻿using FluentAssertions;
using NetSuiteAccess;
using NetSuiteAccess.Services.Common;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using Netco.Logging;

namespace NetSuiteTests
{
	[ TestFixture ]
	public class CommonTests : BaseTest
	{
		private INetSuiteCommonService _commonService;

		[ SetUp ]
		public void Init()
		{
			this._commonService = new NetSuiteFactory().CreateCommonService( this.Config );
		}

		[ Test ]
		public async Task GetLocationsAsync()
		{
			var locations = await this._commonService.GetLocationsAsync( CancellationToken.None );
			locations.Should().NotBeNullOrEmpty();
		}

		[ Test ]
		public async Task GetLocationsByNameAsync()
		{
			var locationName = "San Francisco";
			var location = await this._commonService.GetLocationByNameAsync( locationName, CancellationToken.None, Mark.Blank() );
			location.Should().NotBeNull();
		}

		[ Test ]
		public async Task GetAccountsAsync()
		{
			var accounts = await this._commonService.GetAccountsAsync( CancellationToken.None );
			accounts.Should().NotBeNullOrEmpty();
		}
	}
}