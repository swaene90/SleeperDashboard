using SleeperDashboard.Model.Player;

namespace SleeperDashboard.Helper
{
    public static class PlayerMapper
    {
        public static Player ToModel(this Data.Entity.Player player)
        {
            if (player == null)
            {
                return new Player();
            }

            return new Player()
            {
                Hashtag = player.Hashtag,
                DepthChartPosition = player.DepthChartPosition,
                Status = player.Status,
                Sport = player.Sport,
                FantasyPositions = player.FantasyPositions?.Split(",").ToList(),
                Number = player.Number,
                SearchLastName = player.SearchLastName,
                InjuryStartDate = player.InjuryStartDate,
                Weight = player.Weight,
                Position = player.Position,
                PracticeParticipation = player.PracticeParticipation,
                SportradarId = player.SportradarId,
                Team = player.Team,
                LastName = player.LastName,
                College = player.College,
                FantasyDataId = player.FantasyDataId,
                InjuryStatus = player.InjuryStatus,
                PlayerId = player.PlayerId,
                Height = player.Height,
                SearchFullName = player.SearchFullName,
                Age = player.Age,
                StatsId = int.TryParse( player.StatsId,out var result) ? result : 0,
                BirthCountry = player.BirthCountry,
                EspnId = int.TryParse(player.EspnId, out var espnId) ? espnId : 0,
                SearchRank = player.SearchRank,
                FirstName = player.FirstName,
                DepthChartOrder = player.DepthChartOrder,
                YearsExp = player.YearsExp,
                RotowireId = int.TryParse(player.RotowireId, out var rotowireId) ? rotowireId : 0,
                RotoworldId = player.RotoworldId,
                SearchFirstName = player.SearchFirstName
            };
        }

        public static Data.Entity.Player ToEntity(this Player player)
        {
            if (player == null)
            {
                return new Data.Entity.Player();
            }

            return new Data.Entity.Player()
            {
                Hashtag = player.Hashtag,
                DepthChartPosition = player.DepthChartPosition,
                Status = player.Status,
                Sport = player.Sport,
                FantasyPositions = player?.FantasyPositions != null ? string.Join(",", player.FantasyPositions.Select(fp => fp)) : string.Empty,
                Number = player?.Number ?? 0,
                SearchLastName = player?.SearchLastName,
                InjuryStartDate = DateTime.TryParse(player?.InjuryStartDate?.ToString(), out var dt) ? dt : null,
                Weight = player?.Weight,
                Position = player?.Position,
                PracticeParticipation = player?.PracticeParticipation,
                SportradarId = player?.SportradarId,
                Team = player?.Team,
                LastName = player?.LastName,
                College = player?.College,
                FantasyDataId = player.FantasyDataId.GetValueOrDefault(),
                InjuryStatus = player?.InjuryStatus?.ToString(),
                PlayerId = player?.PlayerId,
                Height = player?.Height,
                SearchFullName = player?.SearchFullName,
                Age = player?.Age ?? 0,
                StatsId = player?.StatsId.ToString(),
                BirthCountry = player?.BirthCountry?.ToString(),
                EspnId = player?.EspnId?.ToString(),
                SearchRank = player?.SearchRank ?? 0,
                FirstName = player?.FirstName,
                DepthChartOrder = player?.DepthChartOrder ?? 0,
                YearsExp = player?.YearsExp ?? 0,
                RotowireId = player?.RotowireId.ToString(),
                RotoworldId = player?.RotoworldId ?? 0,
                SearchFirstName = player?.SearchFirstName
            };

        }

    }
}
