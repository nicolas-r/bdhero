// Copyright 2012-2014 Andrew C. Dvorak
//
// This file is part of BDHero.
//
// BDHero is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// BDHero is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with BDHero.  If not, see <http://www.gnu.org/licenses/>.

using System;
using DotNetUtils.Net;

namespace UpdateLib
{
    public interface IUpdateObserver
    {
        void OnBeforeCheckForUpdate();
        void OnUpdateReadyToDownload(Update update);
        void OnBeforeDownloadUpdate(Update update);
        void OnUpdateDownloadProgressChanged(Update update, FileDownloadProgress progress);
        void OnUpdateException(Exception exception);
        void OnUpdateReadyToInstall(Update update);
        void OnNoUpdateAvailable();
        bool ShouldInstallUpdate(Update update);
        void OnBeforeInstallUpdate(Update update);
    }
}