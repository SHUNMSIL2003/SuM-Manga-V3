﻿if (document.getElementById('creatorsupmitform').style.display == 'none') { document.getElementById('creatorsupmitform').style.display = 'block'; document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight + document.getElementById('creatorsupmitform').offsetHeight + 'px'; } else { document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight - document.getElementById('creatorsupmitform').offsetHeight + 'px'; document.getElementById('creatorsupmitform').style.display = 'none'; }