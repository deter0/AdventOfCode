local function readFile(path)
	local file = io.open(path, "rb");
	if (not file) then
		return nil;
	end
	local content = file:read("*a");
	file:close();
	return content;
end

local inputText = readFile("input.txt");

local function splitString(str, sep)
	local lines = {};
	for split in string.gmatch(str, "([^"..sep.."]+)") do
		lines[#lines+1] = split;
	end
	return lines;
end

local depth = 0;
local hPos = 0;
local aim = 0;

local lines = splitString(inputText, "\n");
for i, line in ipairs(lines) do
	local instruction = string.match(line, "%a+");
	local value = tonumber(string.match(line, "%d+"));
	print(instruction, value);
	if (instruction == "forward") then
		hPos = hPos + value;
		depth = depth + aim * value;
	elseif (instruction == "down") then
		aim = aim + value;
	elseif (instruction == "up") then
		aim = aim - value;
	end
end

print(hPos * depth);